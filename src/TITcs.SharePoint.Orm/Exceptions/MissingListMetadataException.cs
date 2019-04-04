using System;

namespace TITcs.SharePoint.Orm.Exceptions
{
    public class MissingListMetadataException : Exception
    {
        public MissingListMetadataException(string message) : base(message)
        {
        }
        public MissingListMetadataException() : base()
        {
        }
    }
}
