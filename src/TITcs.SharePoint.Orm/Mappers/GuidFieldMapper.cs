using System;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class GuidFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            try
            {
                return Guid.Parse(field.ToString());
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
