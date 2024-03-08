using AutoMapper;
using PolicyAssignment.DAL.Entities;
using PolicyAssignment.DAL.Repositories.Interface;
using PolicyAssignment.Models.RequestModels;
using PolicyAssignment.Models.ResponseModels;
using PolicyAssignment.Services.Interface;

namespace PolicyAssignment.Services.Implemented
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHtmlMapperServiceV2 _htmlMapperV2;
        private readonly IHtmlToPDFService _htmlToPDFService;
        private readonly IDocumentCreationService _documentCreationService;


        public UserService(IDocumentCreationService documentCreationService ,IUserRepository userRepository,IHtmlToPDFService htmlToPDFService, IMapper mapper , IHtmlMapperServiceV2 htmlMapperV2)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._htmlMapperV2 = htmlMapperV2;
            this._htmlToPDFService = htmlToPDFService;
            this._documentCreationService = documentCreationService;
        }

        public async Task<string> CreateUserAsync(UserCreationModel userRequest)
        {
            User user = _mapper.Map<User>(userRequest);
            User created_user = await _userRepository.CreateAsync(user);
            return created_user.Name;
        }

        public async Task<UserDetailsResponseModel> GetUserDetailsAsync(UserDetailsRequestModel request)
        {
            User user = await _userRepository.GetUserAsync(request);
            UserDetailsResponseModel response = _mapper.Map<UserDetailsResponseModel>(user);
            return response;
        }

        public async Task<string> HtmlToPDF(UserDetailsRequestModel userRequest)
        {
            UserDetailsResponseModel userDetails = await GetUserDetailsAsync(userRequest);
            string mappedTemplate = await _htmlMapperV2.GetMappedHtmlAsync(userDetails);
            byte[] pdfData = await _htmlToPDFService.GetByteArrayAsync(mappedTemplate);
            Document document = _mapper.Map<Document>(userRequest);
            document.Data = pdfData;
            string response = _documentCreationService.SaveData(document);  

            return $"File creation {response} created for Policy Number {document.PolicyNumber}";
        }
    }


}
