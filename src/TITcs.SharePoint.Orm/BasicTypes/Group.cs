using System.Collections.Generic;

namespace TITcs.SharePoint.Orm.BasicTypes
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<User> Users { get; set; }
    }
}
