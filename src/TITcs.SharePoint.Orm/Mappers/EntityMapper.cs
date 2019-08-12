using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TITcs.SharePoint.Orm.Attributes;
using TITcs.SharePoint.Orm.Entities;
using TITcs.SharePoint.Orm.Interfaces;

namespace TITcs.SharePoint.Orm.Mappers
{
    public class EntityMapper<TEntity> : IEntityMapper<TEntity> where TEntity : SharePointItem
    {
        #region fields and properties

        private static Dictionary<SPFieldType, IFieldMapper> fieldMappers = new Dictionary<SPFieldType, IFieldMapper>()
        {
            { SPFieldType.Invalid, new ImageFieldMapper()},
            { SPFieldType.Integer, new IntegerFieldMapper()},
            { SPFieldType.Text, new TextFieldMapper()},
            { SPFieldType.Note, new TextFieldMapper()},
            { SPFieldType.DateTime, new DateTimeFieldMapper()},
            { SPFieldType.Counter, new CounterFieldMapper()},
            { SPFieldType.Choice, new TextFieldMapper()},
            { SPFieldType.Lookup, new LookupFieldMapper()},
            { SPFieldType.Boolean, new BooleanFieldMapper()},
            { SPFieldType.Number, new NumberFieldMapper()},
            { SPFieldType.Currency, new NumberFieldMapper()},
            { SPFieldType.URL, new UrlFieldMapper()},
            { SPFieldType.Computed, new ComputedFieldMapper()},
            { SPFieldType.Threading, new NotImplementedFieldMapper()},
            { SPFieldType.Guid, new GuidFieldMapper()},
            { SPFieldType.MultiChoice, new TextArrayFieldMapper()},
            { SPFieldType.GridChoice, new NotImplementedFieldMapper()},
            { SPFieldType.Calculated, new NotImplementedFieldMapper()},
            { SPFieldType.File, new FileFieldMapper()},
            { SPFieldType.Attachments, new NotImplementedFieldMapper()},
            { SPFieldType.User, new LookupFieldMapper()},
            { SPFieldType.Recurrence, new NotImplementedFieldMapper()},
            { SPFieldType.CrossProjectLink, new NotImplementedFieldMapper()},
            { SPFieldType.ModStat, new NotImplementedFieldMapper()},
            { SPFieldType.Error, new NotImplementedFieldMapper()},
            { SPFieldType.ContentTypeId, new NotImplementedFieldMapper()},
            { SPFieldType.PageSeparator, new NotImplementedFieldMapper()},
            { SPFieldType.ThreadIndex, new NotImplementedFieldMapper()},
            { SPFieldType.WorkflowStatus, new NotImplementedFieldMapper()},
            { SPFieldType.AllDayEvent, new NotImplementedFieldMapper()},
            { SPFieldType.WorkflowEventType, new NotImplementedFieldMapper()},
            { SPFieldType.Geolocation, new NotImplementedFieldMapper()},
            { SPFieldType.OutcomeChoice, new NotImplementedFieldMapper()},
            { SPFieldType.MaxItems, new NotImplementedFieldMapper()},
        };

        #endregion

        #region constructors

        #endregion

        #region events and methods

        public TEntity Map(SPListItem item)
        {

            var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            var fieldName = string.Empty;

            typeof(TEntity).GetProperties().ToList().ForEach((prop) =>
            {
                try
                {

                    var customAttribute = prop.GetCustomAttribute<SharePointFieldAttribute>();
                    if (customAttribute != null)
                    {
                        fieldName = customAttribute.Name;

                        // in case there is a property FileSystemObjectType on the TEntity object
                        if (string.Compare(fieldName, "FileSystemObjectType", true) == 0)
                        {
                            if (prop.PropertyType == typeof(string))
                            {
                                prop.SetValue(entity, item.FileSystemObjectType.ToString());
                            }
                        }
                        else
                        {
                            if (item.Fields.ContainsField(fieldName))
                            {
                                var field = item.Fields.GetFieldByInternalName(fieldName);
                                var value = TryGetFieldValue(item, field);
                                if (value != null)
                                {
                                    prop.SetValue(entity, fieldMappers[field.Type].Map(value));
                                }
                            }
                            else
                            {
                                if (fieldName.Equals("File"))
                                {
                                    prop.SetValue(entity, fieldMappers[SPFieldType.File].Map(item.File));
                                }
                            }
                        }
                    }
                    else
                    {
                        // in case no attribute was found, try use the property name
                        if (item.Fields.ContainsField(prop.Name))
                        {
                            var field = item.Fields.GetFieldByInternalName(prop.Name);
                            var value = TryGetFieldValue(item, field);
                            if (value != null)
                            {
                                prop.SetValue(entity, fieldMappers[field.Type].Map(field));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    TITcs.SharePoint.Commons.Logging.Logger.Instance.Debug("EntityMapper.Map", "PropertyName: {0}, Error: {1}", prop.Name, e.Message);
                    throw;
                }
            });

            return entity;
        }

        #region private 

        private object TryGetFieldValue(SPListItem listItem, SPField field)
        {
            try
            {
                if (listItem[field.Id] != null || string.IsNullOrEmpty(field.DefaultValue))
                {
                    return listItem[field.Id];
                }

                return null;
            }
            catch (Exception e)
            {
                TITcs.SharePoint.Commons.Logging.Logger.Instance.Debug("EntityMapper.TryGetFieldValue", "Column Name = {0}, Error = {1}", field.InternalName, e.Message);
                return null;
            }
        }

        #endregion

        #endregion
    }
}
