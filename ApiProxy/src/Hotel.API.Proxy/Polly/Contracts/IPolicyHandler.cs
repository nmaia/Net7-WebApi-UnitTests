using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Proxy.Polly.Contracts
{
    public interface IPolicyHandler
    {
        Task<IActionResult> WrapPolicySendAsync(HttpRequestMessage request);
    }
}
