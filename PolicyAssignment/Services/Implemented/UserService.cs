using AutoMapper;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Services.Implemented
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserDetailsResponse> GetUserDetailsAsync(PolicyRequestModel request)
        {
            User user = await _userRepository.GetUserAsync(request);
            UserDetailsResponse response = _mapper.Map<UserDetailsResponse>(user);
            return response;
        }
    }


}
