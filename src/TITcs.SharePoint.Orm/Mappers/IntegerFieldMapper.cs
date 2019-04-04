using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class IntegerFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return int.Parse(field.ToString());
        }
    }
}
