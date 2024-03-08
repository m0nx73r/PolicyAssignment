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
        private readonly IUserService _userService;
        private readonly IHandlebarService _handlebarService;

        public UserController(IHtmlMapperService htmlMapper, IUserService userService, IHandlebarService handlebarService)
        {
            this._htmlMapper = htmlMapper;
            this._userService = userService;
            this._handlebarService = handlebarService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserDetails([FromBody]UserDetailsRequestModel policyRequest)
        {
            //calling UserService and DocumentTemplateService Internally
            string mappedHtmlTemplate = await _htmlMapper.GetMappedHtmlAsync(policyRequest);
            return Ok(mappedHtmlTemplate);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCreationModel userRequest)
        {
            string response =  await _userService.CreateUserAsync(userRequest);

            UserResponseModel responseModel = new UserResponseModel();

            responseModel.Name = response;
            responseModel.Status = "200";

            return Ok(responseModel);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            string htmlContent = await _handlebarService.getHtmlContent();
            return Ok(htmlContent);
        }
    }
}
