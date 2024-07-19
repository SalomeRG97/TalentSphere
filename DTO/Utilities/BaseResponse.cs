namespace DTO.Utilities
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
