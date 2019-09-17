namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface IQuerySpecification
    {
        string Caml { get; set; }
        string PagingInfo { get; set; }
        string Folder { get; set; }
        string ViewFields { get; set; }
        string ProjectedFields { get; set; }
        string Joins { get; set; }
        uint RowLimit { get; set; }
    }
}
