using Newtonsoft.Json;
using Admin.DTO.Utilities;
using Admin.Interfaces.Utilities;
using System.Text;

namespace Utilidades
{
    public class HttpBase : IHttpBase
    {
        private readonly HttpClient _httpClient;

        protected HttpBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponse<R>> Get<R>(string uri)
        {

            var response = await _httpClient.GetAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseResponse<R>>(responseStream);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new ArgumentException("NoContent");
            }
            else
            {
                throw new Exception($"Error to get the query {uri} Status:{response.StatusCode} Content:{response.Content}");
            }

        }

        public async Task<BaseResponse<R>> Post<R, S>(string uri, S Element)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Element), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseResponse<R>>(responseStream);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }

        }

        public async Task<BaseResponse<R>> Put<R, S>(string uri, S Element)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Element), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content);

            response.EnsureSuccessStatusCode();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject
                    <BaseResponse<R>>(responseStream);
            }
            else { throw new Exception($"Error to get the query"); }

        }

        public async Task<BaseResponse<R>> Delete<R>(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject
                    <BaseResponse<R>>(responseStream);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new ArgumentException("NoContent");
            }
            else
            {
                throw new Exception($"Error to get the query");
            }

        }
    }
}
