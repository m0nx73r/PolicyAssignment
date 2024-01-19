using PolicyAssignment.CustomAttributes;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Interface;
using System.Reflection;

namespace PolicyAssignment.Services.Implemented
{
    public class HtmlMapperService : IHtmlMapperService
    {

        private readonly IDocumentTemplateService _dtService;
        private readonly IUserService _userService;

        public HtmlMapperService(IUserService userService, IDocumentTemplateService dtService)
        {
            this._userService = userService;
            this._dtService = dtService;
        }

        public async Task<string> GetMappedHtmlAsync(PolicyRequestModel request)
        {
            UserDetailsResponse userDetails = await _userService.GetUserDetailsAsync(request);
            string template = await _dtService.GetDocumentTemplateContentAsync(1);

            string mappedHtmlTemplate = PopulateTemplate(userDetails, template);
            
            return mappedHtmlTemplate;
        }

        public string PopulateTemplate<T>(T data, string htmlTemplate)
        {
            //Retrieves all the properties of T
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
