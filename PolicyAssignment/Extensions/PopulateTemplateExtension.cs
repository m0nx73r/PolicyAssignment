using PolicyAssignment.CustomAttributes;
using PolicyAssignment.Services.Implemented;
using System.Reflection;

namespace PolicyAssignment.Extensions
{
    public static class PopulateTemplateExtension
    {
        //Injecting Extension Method in string class, so it can be directly used in service
        public static string PopulateTemplate<T>(this string htmlTemplate, T data)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                //Retrieves all Custom Attribute, which is MapHtmlDataAttribute here
                var attribute = property.GetCustomAttribute<MapHtmlDataAttribute>();
                if (attribute != null)
                {
                    //Retrieves the value of the property from object using reflection 
                    var value = property.GetValue(data)?.ToString() ?? string.Empty;
                    //replaces the Fieldname  with value which is the data coming from repository
                    htmlTemplate = htmlTemplate.Replace(attribute.FieldName, value);
                }
            }
            return htmlTemplate;
        }
    }
}
