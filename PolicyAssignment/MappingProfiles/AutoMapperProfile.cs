
using AutoMapper;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;

namespace PolicyAssignment.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserDetailsResponseModel>();
            CreateMap<UserCreationModel, User>();
            CreateMap<UserDetailsRequestModel, Document>();
        }
    }
}
