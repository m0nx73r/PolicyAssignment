using PolicyAssignment.DAL.DbContexts;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PolicyAssignment.DAL.Repositories.Implemented
{
    public class DocumentTemplateRepository : IDocumentTemplateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentTemplateRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<DocumentTemplate> GetDocument(int id)
        {
            DocumentTemplate template = await _dbContext.DocumentTemplates.FindAsync(id);
            return template;
        }
    }
}
