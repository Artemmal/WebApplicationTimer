namespace WebApplicationTimer.Models
{
    public class Timer
    {
        public Guid Id { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string WebhookUrl { get; set; }
        public bool IsExpired { get; set; }

        private Timer() { }

        public Timer(int hours, int minutes, int seconds, string webhookUrl)
        {
            Id = Guid.NewGuid();
            ExpirationTime = DateTime.UtcNow.AddHours(hours)
                                             .AddMinutes(minutes)
                                             .AddSeconds(seconds);
            WebhookUrl = webhookUrl;
            IsExpired = false;
        }
    }
}
