namespace WebApplicationTimer.Interfaces
{
    public interface IWebhookService
    {
        Task SendWebhookAsync(string url);
    }
}
