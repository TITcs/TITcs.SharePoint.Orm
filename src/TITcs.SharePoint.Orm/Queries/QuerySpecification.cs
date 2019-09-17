using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Queries
{
    public class QuerySpecification : IQuerySpecification
    {
        public string Caml { get; set; }
        public string PagingInfo { get; set; }
        public string Folder { get; set; }
        public uint RowLimit { get; set; }
        public string ViewFields { get; set; }
        public string ProjectedFields { get; set; }
        public string Joins { get; set; }
    }
}
