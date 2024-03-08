using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;

namespace PolicyAssignment.Services.Interface
{
    public interface IUserService
    {
        public Task<UserDetailsResponseModel> GetUserDetailsAsync(UserDetailsRequestModel policyRequest);
        public Task<string> CreateUserAsync(UserCreationModel userRequest);
        public Task<string> HtmlToPDF(UserDetailsRequestModel userRequest);
    }
}
