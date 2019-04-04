using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class CounterFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            return (int)field;
        }
    }
}
