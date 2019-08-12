using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class ComputedFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            if (field == null) return string.Empty;

            return field.ToString();
        }
    }
}
