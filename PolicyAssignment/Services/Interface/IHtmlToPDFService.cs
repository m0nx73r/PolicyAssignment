namespace PolicyAssignment.Services.Interface
{
    public interface IHtmlToPDFService
    {
        public Task<byte[]> GetByteArrayAsync(string mappedHtmlbool);
    }
}
