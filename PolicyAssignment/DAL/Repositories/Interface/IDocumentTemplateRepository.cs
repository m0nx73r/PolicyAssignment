using PolicyAssignment.DAL.Entities;

namespace PolicyAssignment.DAL.Repositories.Interface
{
    public interface IDocumentTemplateRepository
    {
        Task<DocumentTemplates> GetDocument(int id);
    }
}
