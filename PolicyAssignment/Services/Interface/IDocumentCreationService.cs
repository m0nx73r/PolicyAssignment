
using PolicyAssignment.DAL.Entities;

namespace PolicyAssignment.Services.Interface
{
    public interface IDocumentCreationService
    {
        public string SaveData(Document document);
    }
}
