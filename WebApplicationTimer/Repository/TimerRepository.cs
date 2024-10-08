using WebApplicationTimer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Timer = WebApplicationTimer.Models.Timer;

namespace WebApplicationTimer.Repository
{
    public class TimerRepository : ITimerRepository
    {
        private readonly TimerContext _context;

        public TimerRepository(TimerContext context)
        {
            _context = context;
        }

        public async Task AddTimerAsync(Timer timer)
        {
            _context.Timers.Add(timer);
            await _context.SaveChangesAsync();
        }

        public async Task<Timer?> GetTimerByIdAsync(Guid id)
        {
            return await _context.Timers.FindAsync(id);
        }

        public async Task<IEnumerable<Timer>> GetExpiredTimersAsync()
        {
            return await _context.Timers
                .Where(t => t.ExpirationTime <= DateTime.UtcNow && !t.IsExpired)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
