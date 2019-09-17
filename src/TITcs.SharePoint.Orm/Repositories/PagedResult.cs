using System.Collections.Generic;
using TITcs.SharePoint.Orm.Entities;

namespace TITcs.SharePoint.Orm.Repositories
{
    public class PagedResult<TEntity> where TEntity : SharePointItem
    {
        #region fields and properties

        public IEnumerable<TEntity> Results { get; set; } = new List<TEntity>();
        public string PagingInfo { get; set; } = string.Empty;
        public int Total { get; set; }

        #endregion

        #region constructors

        #endregion
    }
}
