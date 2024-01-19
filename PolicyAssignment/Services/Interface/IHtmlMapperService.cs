using PolicyAssignment.Models.RequestModels;

namespace PolicyAssignment.Services.Interface
{
    public interface IHtmlMapperService
    {
        public Task<String> GetMappedHtmlAsync(PolicyRequest request);
    }
}
