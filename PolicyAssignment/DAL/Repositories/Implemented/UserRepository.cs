using Microsoft.AspNetCore.Mvc;
using PolicyAssignment.DAL.DbContexts;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;

namespace PolicyAssignment.DAL.Repositories.Implemented
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext context) {
            this._dbContext = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(UserDetailsRequestModel request)
        {
            return await _dbContext.Users.FindAsync(request.PolicyNumber);
        }

        public IEnumerable<User> GetUsers()
        {
            using(ApplicationDbContext dbContext = _dbContext)
            {
                return dbContext.Set<User>();
            }
        }

    }
}
