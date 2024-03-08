using AutoMapper;
using PolicyAssignment.Extensions;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Services.Implemented
{
    public class HtmlMapperServiceV2 : IHtmlMapperServiceV2
    {
        private readonly IDocumentTemplateService _dtService;

        public HtmlMapperServiceV2(IDocumentTemplateService dtService)
        {
            this._dtService = dtService;
        }
        public async Task<string> GetMappedHtmlAsync(UserDetailsResponseModel userDetails)
        {
            //UserDetailsResponseModel userDetails = await _userService.GetUserDetailsAsync(request);
            string template = await _dtService.GetDocumentTemplateContentAsync(1);

            string response = await template.PopulateTemplateUsingHandlebars(userDetails);
            return response;
        }
    }
}
