using System;
using TITcs.SharePoint.Orm.BasicTypes;

namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface ISharePointItem
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        Lookup Author { get; set; }
    }
}
