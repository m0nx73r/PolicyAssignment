using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;

namespace PolicyAssignment.Services.Interface
{
    public interface IUserService
    {
        public Task<UserDetailsResponse> GetUserDetailsAsync(PolicyRequest request);
    }
}
