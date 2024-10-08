using WebApplicationTimer.Repository;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using WebApplicationTimer.Interfaces;
using Timer = WebApplicationTimer.Models.Timer;

namespace WebApplicationTimer.Services
{
    public class TimerBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public TimerBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var timerRepository = scope.ServiceProvider.GetRequiredService<ITimerRepository>();

                    // Retrieve and process expired timers
                    var expiredTimers = await timerRepository.GetExpiredTimersAsync();

                    foreach (var timer in expiredTimers)
                    {
                        // Process each expired timer
                        await timerRepository.SaveChangesAsync();
                    }
                }

                // Delay until the next check
                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
        }
    }
}
