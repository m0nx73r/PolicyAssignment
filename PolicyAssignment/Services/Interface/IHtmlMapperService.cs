using PolicyAssignment.Models.RequestModels;

namespace PolicyAssignment.Services.Interface
{
    public interface IHtmlMapperService
    {
        public Task<string> GetMappedHtmlAsync(UserDetailsRequestModel request);

    }
}
