using System.ComponentModel.DataAnnotations;

namespace PolicyAssignment.DAL.Entities
{
    public class User
    {
        public string Name { get; set; }

        [Key]
        public string PolicyNumber { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Occupation { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public string ProductCode {  get; set; }
        public string EmailAddress { get; set; }


    }
}
