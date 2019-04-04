using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class TextFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return field.ToString();
        }
    }
}
