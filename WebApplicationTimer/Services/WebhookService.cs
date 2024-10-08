using WebApplicationTimer.Interfaces;

namespace WebApplicationTimer.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly HttpClient _httpClient;

        public WebhookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendWebhookAsync(string url)
        {
            await _httpClient.PostAsync(url, null);
        }
    }
}
