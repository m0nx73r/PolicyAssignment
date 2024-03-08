using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;

namespace PolicyAssignment.Services.Interface
{
    public interface IHtmlMapperServiceV2
    {
        public Task<String> GetMappedHtmlAsync(UserDetailsResponseModel request);
    }
}
