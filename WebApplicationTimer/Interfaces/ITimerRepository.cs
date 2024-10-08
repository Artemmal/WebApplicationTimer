using Timer = WebApplicationTimer.Models.Timer;

namespace WebApplicationTimer.Interfaces

{
    public interface ITimerRepository
    {
        Task AddTimerAsync(Timer timer);
        Task<Timer?> GetTimerByIdAsync(Guid id);
        Task<IEnumerable<Timer>> GetExpiredTimersAsync();
        Task SaveChangesAsync();
    }
}
