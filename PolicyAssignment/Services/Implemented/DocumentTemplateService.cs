using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Services.Implemented
{
    public class DocumentTemplateService : IDocumentTemplateService
    {

        private readonly IDocumentTemplateRepository _repository;
        public DocumentTemplateService(IDocumentTemplateRepository repository) { 
            this._repository = repository;
        }

        public async Task<string> GetDocumentTemplateContentAsync(int templateId)
        {
            DocumentTemplates template = await _repository.GetDocument(templateId);

            return template.Content;
        }
    }
}
