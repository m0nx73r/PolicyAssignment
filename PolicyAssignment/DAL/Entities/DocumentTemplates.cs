namespace PolicyAssignment.DAL.Entities
{
    public class DocumentTemplates
    {
        public int Id { get; set; }
        public string DocumentCode { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedUser {  get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDateTime { get; set;}

    }
}
