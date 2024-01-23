using System.ComponentModel.DataAnnotations;

namespace PolicyAssignment.DAL.Entities
{
    public class Document
    {
        public Byte[] Data { get; set; }
        public string Email { get; set; }
        public string ProductCode { get; set; }
        [Key]
        public string PolicyNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
