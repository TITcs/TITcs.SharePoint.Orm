using Microsoft.SharePoint;

namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface ISharePointContext
    {
        SPWeb Web { get; }
    }
}
