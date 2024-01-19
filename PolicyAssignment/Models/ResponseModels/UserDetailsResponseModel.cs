
using PolicyAssignment.CustomAttributes;

namespace PolicyAssignment.Models.ResponseModels
{
    public class UserDetailsResponseModel
    {
        //template var == attribute value
        [MapHtmlData("{{Name}}")]
        public string Name { get; set; }
        
        [MapHtmlData("{{PolicyNumber}}")]
        public string PolicyNumber { get; set; }

        [MapHtmlData("{{Age}}")]
        public int Age { get; set; }

        [MapHtmlData("{{Salary}}")]
        public int Salary { get; set; }

        [MapHtmlData("{{Occupation}}")]
        public string Occupation { get; set; }

        [MapHtmlData("{{PolicyExpiryDate}}")]
        public DateTime PolicyExpiryDate { get; set; }

        [MapHtmlData("{{ProductCode}}")]
        public string ProductCode { get; set; }

        //email is not needed as of now
        //public string EmailAddress { get; set; }
    }
}
