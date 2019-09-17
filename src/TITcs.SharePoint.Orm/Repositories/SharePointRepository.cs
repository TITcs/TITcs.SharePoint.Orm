using Microsoft.SharePoint;
using System;
using System.Linq;
using System.Reflection;
using TITcs.SharePoint.Commons;
using TITcs.SharePoint.Commons.Extensions;
using TITcs.SharePoint.Orm.Attributes;
using TITcs.SharePoint.Orm.Entities;
using TITcs.SharePoint.Orm.Exceptions;
using TITcs.SharePoint.Orm.Interfaces;
using TITcs.SharePoint.Orm.Mappers;

namespace TITcs.SharePoint.Orm.Repositories
{
    public abstract class SharePointRepository<TEntity> : ISharePointRepository<TEntity> where TEntity : SharePointItem
    {
        #region fields and properties

        private readonly ISharePointContext context;
        private readonly string listTitle;
        private readonly string callInformation;
        private readonly SPList list;
        private readonly IEntityMapper<TEntity> mapper;
        public ISharePointContext Context => this.context;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes the repository based on a ISharepointContext object.
        /// </summary>
        /// <param name="context">ISharepointContext object representing the web context.</param>
        public SharePointRepository(ISharePointContext context)
        {
            this.context = context;
            this.listTitle = GetListTitle();
            this.callInformation = GetCallInformation();
            this.list = GetList();
            mapper = new EntityMapper<TEntity>();
        }

        #endregion

        #region events and methods

        /// <summary>
        /// Gets an item by its Id.
        /// </summary>
        /// <param name="id">Id of the item to return.</param>
        /// <returns>Returns a domain object representing the SPListItem found.</returns>
        public TEntity GetById(int id)
        {
            return Call<TEntity>(() =>
            {
                return mapper.Map(list.GetItemById(id));
            }, "GetById");
        }

        /// <summary>
        /// Returns the count of items that match the specified criteria.
        /// </summary>
        /// <param name="criteria">Query criteria to satisfy.</param>
        /// <returns>Number of items that satify the criteria.</returns>
        public int Count(IQuerySpecification criteria)
        {
            Guards.GuardAgainstNull(criteria);

            return Call(() =>
            {
                var spQuery = new SPQuery();

                if (!string.IsNullOrWhiteSpace(criteria.Caml))
                {
                    spQuery.Query = criteria.Caml;
                }

                if (!string.IsNullOrWhiteSpace(criteria.Folder))
                {
                    spQuery.Folder = list.FindFolder(criteria.Folder);
                }

                if (!string.IsNullOrWhiteSpace(criteria.PagingInfo))
                {
                    spQuery.ListItemCollectionPosition = new SPListItemCollectionPosition(criteria.PagingInfo);
                }

                return list.GetItems(spQuery).Count;
            }, "Count");
        }

        /// <summary>
        /// Queries the target list based on the specified query criteria.
        /// </summary>
        /// <param name="criteria">Query criteria to satisfy.</param>
        /// <returns>Collection if the returned items that satify the criteria.</returns>
        public PagedResult<TEntity> FindAll(IQuerySpecification criteria)
        {
            Guards.GuardAgainstNull(criteria);

            TITcs.SharePoint.Commons.Logging.Logger.Instance.Debug("SharePointRepository.GetAll", "Caml = {0}, PagingInfo = {1}, Folder = {2}, RowLimit = {3}", criteria.Caml, criteria.PagingInfo, criteria.Folder, criteria.RowLimit);

            return Call(() =>
            {
                var spQuery = new SPQuery();

                if (!string.IsNullOrWhiteSpace(criteria.Caml))
                {
                    spQuery.Query = criteria.Caml;
                }

                if (!string.IsNullOrWhiteSpace(criteria.Folder))
                {
                    spQuery.Folder = list.FindFolder(criteria.Folder);
                }

                // query the list using the original parameters to get the total items that the query would return
                var originalItems = list.GetItems(spQuery);
                var totalItemsCount = originalItems.Count;

                var newSpQuery = GetQuery(criteria);

                newSpQuery.RowLimit = criteria.RowLimit > totalItemsCount ? (uint)totalItemsCount : criteria.RowLimit;

                var finalResults = list.GetItems(newSpQuery);

                return new PagedResult<TEntity>()
                {
                    PagingInfo = finalResults?.ListItemCollectionPosition?.PagingInfo,
                    Results = finalResults.Cast<SPListItem>().Select(item => mapper.Map(item)),
                    Total = totalItemsCount
                };
            }, "FindAll");
        }

        #region private

        private string GetListTitle()
        {
            var titleAttr = this.GetType().GetCustomAttribute<SharePointListAttribute>();
            if (titleAttr == null)
            {
                throw new MissingListMetadataException("Repository is missing mandatory SharePointListAttribute!");
            }

            return titleAttr.Title;
        }
        protected TResult Call<TResult>(Func<TResult> method, string label)
        {
            try
            {
                TITcs.SharePoint.Commons.Logging.Logger.Instance.Debug(string.Concat(callInformation, label), " Before Call");
                var results = method();
                TITcs.SharePoint.Commons.Logging.Logger.Instance.Debug(string.Concat(callInformation, label), " After Call");
                return results;
            }
            catch (Exception exception)
            {
                TITcs.SharePoint.Commons.Logging.Logger.Instance.Unexpected(this.callInformation, exception.Message);
                throw;
            }
        }
        private string GetCallInformation()
        {
            return string.Format("SharePointRepository<{0}>.", this.GetType().FullName);
        }
        private SPList GetList()
        {
            var list = Context.Web.Lists.TryGetList(this.listTitle);
            if (list == null)
            {
                throw new MissingListException(listTitle);
            }
            return list;
        }
        private SPQuery GetQuery(IQuerySpecification criteria)
        {
            var spQuery = new SPQuery();

            if (!string.IsNullOrWhiteSpace(criteria.Caml))
            {
                spQuery.Query = criteria.Caml;
            }

            if (!string.IsNullOrWhiteSpace(criteria.Folder))
            {
                spQuery.Folder = list.FindFolder(criteria.Folder);
            }

            if (!string.IsNullOrWhiteSpace(criteria.ViewFields))
            {
                spQuery.ViewFields = criteria.ViewFields;
            }

            if (!string.IsNullOrWhiteSpace(criteria.Joins))
            {
                spQuery.Joins = criteria.Joins;
            }

            if (!string.IsNullOrWhiteSpace(criteria.ProjectedFields))
            {
                spQuery.ProjectedFields = criteria.ProjectedFields;
            }

            if (!string.IsNullOrWhiteSpace(criteria.PagingInfo))
            {
                spQuery.ListItemCollectionPosition = new SPListItemCollectionPosition(criteria.PagingInfo);
            }

            return spQuery;
        }


        #endregion

        #endregion
    }
}
