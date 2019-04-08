using Microsoft.SharePoint;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Contexts
{
    /// <summary>
    /// Default implementation of a SharePointContext.
    /// </summary>
    public class SharePointContext : ISharePointContext
    {
        #region fields and properties

        private readonly SPWeb web;
        public SPWeb Web => this.web;

        #endregion

        #region constructors

        public SharePointContext(SPWeb web)
        {
            this.web = web;
        }

        #endregion
    }
}
