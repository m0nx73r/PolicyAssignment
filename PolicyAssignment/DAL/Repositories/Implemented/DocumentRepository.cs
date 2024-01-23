using PolicyAssignment.DAL.DbContexts;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;

namespace PolicyAssignment.DAL.Repositories.Implemented
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext context) {
            this._context = context;
        }
        public int SaveDocument(Document request)
        {
            try
            {
                _context.Add(request);
                _context.SaveChanges();
                return 1;
            }
            catch {
                return 0;
            }

        }
    }
}
