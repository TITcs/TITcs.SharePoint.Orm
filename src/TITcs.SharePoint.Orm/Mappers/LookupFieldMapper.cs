using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Linq;
using TITcs.SharePoint.Orm.BasicTypes;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class LookupFieldMapper : IFieldMapper
    {
        public object Map(object field)
        {
            var fieldLookupValue = field as SPFieldLookupValue;
            if (fieldLookupValue != null)
            {
                // successfullt converts to SPFieldLookupValue
                return new Lookup(fieldLookupValue.LookupId, fieldLookupValue.LookupValue);
            }

            var fieldLookupCollection = field as SPFieldLookupValueCollection;
            if (fieldLookupCollection != null)
            {
                var lookups = fieldLookupCollection.ToDictionary(i => i.LookupId, j => j.LookupValue);
                var results = new List<Lookup>();

                if (lookups != null)
                {
                    results.AddRange(lookups.Select(l => new Lookup(l.Key, l.Value)));
                }

                return results;
            }

            var stringLookup = field as string;
            if (stringLookup != null)
            {
                if (stringLookup.IndexOf(";#") > 0)
                {
                    var lkpValue = new SPFieldLookupValue(stringLookup);
                    return new Lookup(lkpValue.LookupId, lkpValue.LookupValue);
                }
            }

            // single selection user fields
            var userStringLookup = field as string;
            if (userStringLookup != null)
            {
                if (userStringLookup.IndexOf(";#") > 0)
                {
                    var lkpValue = new SPFieldLookupValue(userStringLookup);

                    return new Lookup(lkpValue.LookupId, lkpValue.LookupValue);
                }

                return userStringLookup;
            }

            // multiple selection user fields
            var multipleUserValues = field as SPFieldUserValueCollection;
            if (multipleUserValues != null)
            {
                var results = new List<Lookup>();

                if (multipleUserValues != null)
                {
                    results.AddRange(multipleUserValues.Select(u => new Lookup(u.LookupId, u.LookupValue)));
                }

                return results;
            }

            return null;
        }
    }
}
