using System.Linq;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class TextArrayFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            if (field.GetType() == typeof(string))
            {
                return field.ToString().Replace(";#", "|").Split('|').ToArray().Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();
            }

            return new string[] { };
        }
    }
}
