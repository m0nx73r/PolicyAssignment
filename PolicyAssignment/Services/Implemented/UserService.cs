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

        public async Task<string> CreateUserAsync(UserCreationModel userRequest)
        {
            User user = _mapper.Map<User>(userRequest);
            User created_user = await _userRepository.CreateAsync(user);
            return created_user.Name;
        }

        public async Task<UserDetailsResponseModel> GetUserDetailsAsync(PolicyRequestModel request)
        {
            User user = await _userRepository.GetUserAsync(request);
            UserDetailsResponseModel response = _mapper.Map<UserDetailsResponseModel>(user);
            return response;
        }

    }


}
