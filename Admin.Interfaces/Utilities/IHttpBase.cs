using Admin.DTO.Utilities;

namespace Admin.Interfaces.Utilities
{
    public interface IHttpBase
    {
        Task<BaseResponse<R>> Delete<R>(string uri);
        Task<BaseResponse<R>> Get<R>(string uri);
        Task<BaseResponse<R>> Post<R, S>(string uri, S Element);
        Task<BaseResponse<R>> Put<R, S>(string uri, S Element);
    }
}