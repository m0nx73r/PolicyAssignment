namespace PolicyAssignment.Services.Interface
{
    public interface IDocumentTemplateService
    {
        public Task<string> GetDocumentTemplateContentAsync(int templateId);
    }
}
