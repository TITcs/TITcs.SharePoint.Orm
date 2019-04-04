using Newtonsoft.Json;
using System;
using TITcs.SharePoint.Orm.Attributes;
using TITcs.SharePoint.Orm.BasicTypes;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Entities
{
    public class SharePointItem : ISharePointItem
    {
        [JsonProperty("id")]
        [SharePointField("ID")]
        public int Id { get; set; }

        [JsonProperty("title")]
        [SharePointField("Title")]
        public virtual string Title { get; set; }

        [JsonProperty("created")]
        [SharePointField("Created")]
        public virtual DateTime Created { get; set; }

        [JsonProperty("author")]
        [SharePointField("Author")]
        public virtual Lookup Author { get; set; }

        [JsonProperty("file")]
        [SharePointField("File")]
        public virtual File File { get; set; }

        [JsonProperty("fileRef")]
        [SharePointField("FileRef")]
        public virtual string FileRef { get; set; }

        [JsonProperty("modified")]
        [SharePointField("Modified")]
        public virtual DateTime Modified { get; set; }
    }
}
