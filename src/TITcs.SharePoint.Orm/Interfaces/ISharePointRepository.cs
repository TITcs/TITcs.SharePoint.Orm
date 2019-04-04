using System.Collections.Generic;
using TITcs.SharePoint.Orm.Entities;

namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface ISharePointRepository<TEntity> where TEntity : SharePointItem
    {
        ISharePointContext Context { get; }
        TEntity GetById(int id);
        IEnumerable<TEntity> FindAll(IQuerySpecification criteria);
        int Count(IQuerySpecification criteria);
    }
}
