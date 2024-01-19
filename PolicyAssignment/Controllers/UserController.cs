using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Implemented;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly IHtmlMapperService _htmlMapper;

        public UserController(IHtmlMapperService htmlMapper)
        {
            this._htmlMapper = htmlMapper;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserDetails([FromBody]PolicyRequest policyRequest)
        {
            //calling UserService and DocumentTemplateService Internally
            string mappedHtmlTemplate = await _htmlMapper.GetMappedHtmlAsync(policyRequest);
            return Ok(mappedHtmlTemplate);
        }
    }
}
