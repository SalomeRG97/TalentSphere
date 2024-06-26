using Admin.Interfaces;

namespace Admin.Services
{
    public class RequestResponse : IRequestResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
