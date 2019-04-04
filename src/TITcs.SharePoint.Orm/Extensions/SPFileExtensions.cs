using Microsoft.SharePoint;
using System.IO;
using File = TITcs.SharePoint.Orm.BasicTypes.File;

namespace TITcs.SharePoint.Orm.Extensions
{
    public static class SPFileExtensions
    {
        public static File AsFile(this SPFile file)
        {
            return new File
            {
                Name = file.Name,
                Title = file.Title,
                Created = file.TimeCreated,
                Length = file.Length,
                Url = file.ServerRelativeUrl,
                Extension = Path.GetExtension(file.ServerRelativeUrl),
                Content = file.OpenBinary()
            };
        }
    }
}
