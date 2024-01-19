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

        public UserController(IHtmlMapperService htmlMapper, IUserService userService)
        {
            this._htmlMapper = htmlMapper;
            this._userService = userService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserDetails([FromBody]PolicyRequestModel policyRequest)
        {
            //calling UserService and DocumentTemplateService Internally
            string mappedHtmlTemplate = await _htmlMapper.GetMappedHtmlAsync(policyRequest);
            return Ok(mappedHtmlTemplate);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateUser([FromBody] UserCreationModel userRequest)
        {
            string response =  await _userService.CreateUserAsync(userRequest);

            UserResponseModel responseModel = new UserResponseModel();

            responseModel.name = response;
            responseModel.status = "200";

            return Ok(responseModel);
        }
    }
}
