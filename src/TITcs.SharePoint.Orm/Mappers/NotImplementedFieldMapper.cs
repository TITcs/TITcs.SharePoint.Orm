using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class NotImplementedFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            TITcs.SharePoint.Commons.Logging.Logger.Instance.Information("TITcs.SharePoint.Orm.Mappers.NotImplementedFieldMapper", "Mapper not implemented for the type {0}!", field.GetType().FullName);

            return null;
        }
    }
}
