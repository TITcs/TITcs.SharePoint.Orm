using Microsoft.SharePoint;
using TITcs.SharePoint.Orm.Interfaces;
using TITcs.SharePoint.Orm.Extensions;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class FileFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            var file = field as SPFile;
            return file?.AsFile();
        }
    }
}
