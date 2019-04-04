using System;

namespace TITcs.SharePoint.Orm.Attributes
{
    /// <summary>
    /// Maps a POCO object property to a SharePoint field by relying on the InternalName information.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class SharePointFieldAttribute : Attribute
    {
        #region fields and properties

        public string Name { get; set; }
        public bool LookupText { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Creates a new mapping information.
        /// </summary>
        /// <param name="name">InternalName of the field.</param>
        /// <param name="lookupText">Indicates if the field is a lookup text.</param>
        public SharePointFieldAttribute(string name, bool lookupText = false)
        {
            Name = name;
            LookupText = lookupText;
        }

        #endregion
    }
}
