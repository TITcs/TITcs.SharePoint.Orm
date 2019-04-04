using System;

namespace TITcs.SharePoint.Orm.Exceptions
{
    public class MissingListException : Exception
    {
        public MissingListException(string message) : base(message)
        {
        }
        public MissingListException() : base()
        {
        }
    }
}
