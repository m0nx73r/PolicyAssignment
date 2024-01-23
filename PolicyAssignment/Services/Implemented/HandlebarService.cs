using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Services.Interface;
using HandlebarsDotNet;


namespace PolicyAssignment.Services.Implemented
{
    public class HandlebarService : IHandlebarService
    {
        private readonly IDocumentTemplateRepository _documentTemplateRepository;
        private readonly IUserRepository _userRepository;
        public HandlebarService(IDocumentTemplateRepository documentTemplateRepository, IUserRepository userRepository) { 
            this._documentTemplateRepository = documentTemplateRepository;
            this._userRepository = userRepository;
        }
        public async Task<string> getHtmlContent()
        {
            DocumentTemplate template = await _documentTemplateRepository.GetDocument(1);
            IEnumerable<User> users = _userRepository.GetUsers();

            var compliedTemplate =  Handlebars.Compile(template.Content);

            return compliedTemplate(users);
        }
    }
}
