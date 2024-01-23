using PolicyAssignment.DAL.Entities;

namespace PolicyAssignment.DAL.Repositories.Interface
{
    public interface IDocumentTemplateRepository
    {
        Task<DocumentTemplate> GetDocument(int id);
    }
}
