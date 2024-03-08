namespace PolicyAssignment.Models.RequestModels
{
    public class UserCreationModel
    {
        public string Name { get; set; }
        public string PolicyNumber { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Occupation { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public string ProductCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
