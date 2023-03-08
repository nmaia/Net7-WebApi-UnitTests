using Hotel.API.Proxy.ViewModels.Writing;

namespace Hotel.API.Proxy.Helpers
{
    public class HttpClientHelper
    {
        public static HttpRequestMessage SetHttpRequest(object? model, HttpMethod method, string url)
        {
            var jsonObj = System.Text.Json.JsonSerializer.Serialize(model);
            var content = new StringContent(jsonObj, System.Text.Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage()
            {
                Content = content,
                RequestUri = new Uri(url),
                Method = method
            };

            return request;
        }
    }
}
