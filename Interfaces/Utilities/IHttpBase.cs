
namespace Utilidades
{
    public interface IHttpBase
    {
        Task<R> Delete<R>(string uri);
        Task<R> Get<R>(string uri);
        Task<R> Post<R, S>(string uri, S Element);
        Task<R> Put<R, S>(string uri, S Element);
    }
}