using System.Collections.Generic;

namespace TITcs.SharePoint.Orm.BasicTypes
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }        
        public string Login { get; set; }
        public string Email { get; set; }
        public string Claims { get; set; }
        public IReadOnlyCollection<Group> Groups { get; set; }
    }
}
