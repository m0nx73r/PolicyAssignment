using Microsoft.AspNetCore.Mvc;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HtmlToPdfController : ControllerBase
    {
        private readonly IUserService _userService;

        public HtmlToPdfController(IUserService userService) {
            this._userService = userService;
        }    

        [HttpPost]
        public async Task<IActionResult> GeneratePDF(UserDetailsRequestModel request) {

            string response = await _userService.HtmlToPDF(request);

            return Ok(response);

        }
    }
}
