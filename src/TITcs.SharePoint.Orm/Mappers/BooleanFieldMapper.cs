using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class BooleanFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return (bool)field;
        }
    }
}
