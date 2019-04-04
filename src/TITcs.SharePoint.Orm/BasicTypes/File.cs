using System;

namespace TITcs.SharePoint.Orm.BasicTypes
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public long Length { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}
