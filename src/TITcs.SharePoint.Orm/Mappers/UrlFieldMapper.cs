using System;
using System.Linq;
using TITcs.SharePoint.Orm.BasicTypes;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class UrlFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            try
            {
                var urlValue = field as string;
                if (urlValue.IndexOf(',') > 0)
                {
                    var parts = urlValue.Split(',');

                    return new Url
                    {
                        Uri = new Uri(parts[0]),
                        Description = string.Join(",", parts.Skip(1).Select(i => i).ToArray())
                    };
                }
            }
            catch (Exception e)
            {
            }

            return null;
        }
    }
}
