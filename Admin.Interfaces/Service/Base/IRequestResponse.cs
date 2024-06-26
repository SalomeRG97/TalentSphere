namespace Admin.Interfaces
{
    public interface IRequestResponse
    {
        string Message { get; set; }
        int StatusCode { get; set; }
    }
}