using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Services.Implemented
{
    public class DocumentCreationService : IDocumentCreationService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentCreationService(IDocumentRepository documentRepository) {
            this._documentRepository = documentRepository;
        }

        public string SaveData(Document document)
        {
            int result = _documentRepository.SaveDocument(document);
            if(result == 0) {
                return "Success";
            }
            else {
                return "Failed";
            }

        }
    }
}
