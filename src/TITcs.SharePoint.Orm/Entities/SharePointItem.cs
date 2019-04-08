using System;
using TITcs.SharePoint.Orm.Attributes;
using TITcs.SharePoint.Orm.BasicTypes;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Entities
{
    public class SharePointItem : ISharePointItem
    {
        [SharePointField("ID")]
        public int Id { get; set; }

        [SharePointField("Title")]
        public virtual string Title { get; set; }

        [SharePointField("Created")]
        public virtual DateTime Created { get; set; }

        [SharePointField("Author")]
        public virtual Lookup Author { get; set; }

        [SharePointField("File")]
        public virtual File File { get; set; }

        [SharePointField("FileRef")]
        public virtual string FileRef { get; set; }

        [SharePointField("Modified")]
        public virtual DateTime Modified { get; set; }
    }
}
