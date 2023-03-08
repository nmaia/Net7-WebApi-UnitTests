using Hotel.API.Proxy.Polly.Contracts;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;

namespace Hotel.API.Proxy.Polly
{
    public class PolicyHandler : ControllerBase, IPolicyHandler
    {
        private readonly AsyncRetryPolicy<IActionResult> _retryPolicy;
        private static AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly AsyncPolicyWrap<IActionResult> _policyWrap;
        private readonly HttpClient _httpClient;

        public PolicyHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();

            _retryPolicy = Policy<IActionResult>
                .Handle<Exception>()
                .RetryAsync();

            if (_circuitBreakerPolicy == null)
            {
                _circuitBreakerPolicy = Policy
                    .Handle<Exception>()
                    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));
            }

            _policyWrap = Policy<IActionResult>
                .Handle<Exception>()
                .FallbackAsync(Content("Sorry, we're currently experiencing issues. Please try again later."))
                .WrapAsync(_retryPolicy)
                .WrapAsync(_circuitBreakerPolicy);
        }

        //todo: this method is returning 200OK for every request, this method needs a refactoring to handle http status code properly
        public async Task<IActionResult> WrapPolicySendAsync(HttpRequestMessage request)
        {
            var response = await _policyWrap.ExecuteAsync(async () => Content(
                await _httpClient.SendAsync(request).Result.Content.ReadAsStringAsync()));

            return response;
        }
    }
}
