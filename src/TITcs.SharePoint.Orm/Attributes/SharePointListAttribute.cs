using System;

namespace TITcs.SharePoint.Orm.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SharePointListAttribute : Attribute
    {
        public string Title { get; set; }

        public SharePointListAttribute(string title)
        {
            Title = title;
        }
    }
}
