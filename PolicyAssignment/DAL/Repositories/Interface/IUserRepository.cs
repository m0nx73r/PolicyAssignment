using PolicyAssignment.DAL.Entities;
using PolicyAssignment.Models.RequestModels;

namespace PolicyAssignment.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetUserAsync(UserDetailsRequestModel request);

        IEnumerable<User> GetUsers();
    }
}
