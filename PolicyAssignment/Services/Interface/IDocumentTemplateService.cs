namespace PolicyAssignment.Services.Interface
{
    public interface IDocumentTemplateService
    {
        public Task<String> GetDocumentTemplateContentAsync(int templateId);
    }
}
