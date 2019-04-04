using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class ImageFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            var imageField = field as Microsoft.SharePoint.Publishing.Fields.ImageFieldValue;
            if (imageField != null)
            {
                return imageField.ImageUrl;
            }
            if (field is double)
            {
                return (double)field;
            }

            return string.Empty;
        }
    }
}
