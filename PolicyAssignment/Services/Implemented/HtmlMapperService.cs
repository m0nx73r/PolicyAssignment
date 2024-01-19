using PolicyAssignment.CustomAttributes;
using PolicyAssignment.Extensions;
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
            //Calling Extension Method
            return template.PopulateTemplate(userDetails);
        }
    }
}
