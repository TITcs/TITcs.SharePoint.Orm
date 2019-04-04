namespace TITcs.SharePoint.Orm.Interfaces
{
    public interface IQuerySpecification
    {
        string Caml { get; set; }
        string PagingInfo { get; set; }
        string Folder { get; set; }
        uint RowLimit { get; set; }
        string ViewXml { get; set; }
    }
}
