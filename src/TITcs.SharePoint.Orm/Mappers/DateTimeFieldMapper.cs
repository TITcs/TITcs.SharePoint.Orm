using System;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class DateTimeFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return (DateTime)field;
        }
    }
}
