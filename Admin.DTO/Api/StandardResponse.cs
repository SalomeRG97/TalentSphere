namespace Admin.DTO
{
    public class StandardResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }

        public StandardResponse(string message, T data)
        {
            Message = message;
            Data = data;
        }
    }
}
