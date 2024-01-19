using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Implemented;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Interface;

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

            string mappedHtmlTemplate = template
            .Replace("{{Name}}", userDetails.Name)
            .Replace("{{PolicyNumber}}", userDetails.PolicyNumber)
            .Replace("{{Age}}", userDetails.Age.ToString())
            .Replace("{{Salary}}", userDetails.Salary.ToString())
            .Replace("{{Occupation}}", userDetails.Occupation)
            .Replace("{{ProductCode}}", userDetails.ProductCode)
            .Replace("{{PolicyExpiryDate}}", userDetails.PolicyExpiryDate.ToString("yyyy-MM-dd"));

            return mappedHtmlTemplate;

        }
    }
}
