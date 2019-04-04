namespace TITcs.SharePoint.Orm.BasicTypes
{
    public class Lookup
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Lookup(int id)
        {
            Id = id;
        }
        public Lookup(int id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
