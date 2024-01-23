using Newtonsoft.Json.Linq;
using PolicyAssignment.CustomAttributes;
using PolicyAssignment.Services.Implemented;
using System.Reflection;

namespace PolicyAssignment.Extensions
{
    public static class HtmlTemplateExtension
    {
        //Injecting Extension Method in string class, so it can be directly used in service
        public static string PopulateTemplateUsingReflection<T>(this string htmlTemplate, T data)
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


        public static async Task<string> PopulateTemplateUsingHandlebars<T>(this string htmlTemplate, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                string mappingEndpoint = "http://localhost:5195/api/HtmlMapper/MapTemplate";

                try
                {
                    // Assuming the data is a JObject
                    HttpResponseMessage response = await client.PostAsJsonAsync(mappingEndpoint, JObject.FromObject(data));

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Fallback method if there is an issue with the mapping endpoint
                        return htmlTemplate.PopulateTemplateUsingReflection(data);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                    Console.WriteLine($"Error in PopulateTemplateUsingHandlebars: {ex.Message}");
                    return htmlTemplate.PopulateTemplateUsingReflection(data);
                }
            }
        }
    }
}