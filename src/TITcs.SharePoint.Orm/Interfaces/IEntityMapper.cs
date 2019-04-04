using Microsoft.SharePoint;
using TITcs.SharePoint.Orm.Entities;

namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface IEntityMapper<TEntity> where TEntity : SharePointItem
    {
        TEntity Map(SPListItem item);
    }
}
