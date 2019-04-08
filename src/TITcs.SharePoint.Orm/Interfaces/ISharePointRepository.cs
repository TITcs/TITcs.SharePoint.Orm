using TITcs.SharePoint.Orm.Entities;
using TITcs.SharePoint.Orm.Repositories;

namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface ISharePointRepository<TEntity> where TEntity : SharePointItem
    {
        ISharePointContext Context { get; }
        TEntity GetById(int id);
        PagedResult<TEntity> FindAll(IQuerySpecification criteria);
        int Count(IQuerySpecification criteria);
    }
}
