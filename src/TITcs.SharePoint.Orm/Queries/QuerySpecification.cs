using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Queries
{
    public class QuerySpecification : IQuerySpecification
    {
        public string Caml { get; set; }
        public string PagingInfo { get; set; }
        public string Folder { get; set; }
        public uint RowLimit { get; set; }
        public string ViewXml { get; set; }
    }
}
