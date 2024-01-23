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

        public HtmlMapperService(IDocumentTemplateService dtService)
        {

            this._dtService = dtService;
        }

        public async Task<string> GetMappedHtmlAsync(UserDetailsRequestModel data)
        {
            string template = await _dtService.GetDocumentTemplateContentAsync(1);
            //Calling Extension Method
            return template.PopulateTemplateUsingReflection(data);
        }
    }
}
