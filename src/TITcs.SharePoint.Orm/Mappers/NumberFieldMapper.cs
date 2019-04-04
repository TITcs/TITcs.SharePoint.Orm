using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class NumberFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return double.Parse(field.ToString());
        }
    }
}
