using Microsoft.EntityFrameworkCore;
using Timer = WebApplicationTimer.Models.Timer;

namespace WebApplicationTimer.Repository
{
    public class TimerContext : DbContext
    {
        public DbSet<Timer> Timers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=timers.db");
    }
}
