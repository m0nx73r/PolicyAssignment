using PolicyAssignment.DAL.Entities;
using PolicyAssignment.Models.RequestModels;

namespace PolicyAssignment.DAL.Repositories.Interface
{
    public interface IDocumentRepository
    {
        public int SaveDocument(Document request);

    }
}
