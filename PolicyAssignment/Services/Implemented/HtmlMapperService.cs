using PolicyAssignment.CustomAttributes;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Implemented;
using PolicyAssignment.DAL.Repositories.Interface;
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

        public async Task<string> GetMappedHtmlAsync(PolicyRequest request)
        {
            UserDetailsResponse userDetails = await _userService.GetUserDetailsAsync(request);
            string template = await _dtService.GetDocumentTemplateContentAsync(1);

            string mappedHtmlTemplate = PopulateTemplate(userDetails, template);
            
            return mappedHtmlTemplate;
        }

        public string PopulateTemplate<T>(T data, string htmlTemplate)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var attribute = property.GetCustomAttribute<MapHtmlDataAttribute>();
                if (attribute != null)
                {
                    var placeholder = $"{{{{{attribute.FieldName}}}}}";
                    var value = property.GetValue(data)?.ToString() ?? string.Empty;
                    htmlTemplate = htmlTemplate.Replace(placeholder, value);
                }
            }

            return htmlTemplate;
        }
    }
}
