using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTimer.Interfaces;
using WebApplicationTimer.Models;
using WebApplicationTimer.Repository;
using Timer = WebApplicationTimer.Models.Timer;

namespace WebApplicationTimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimersController : ControllerBase
    {
        private readonly ITimerRepository _timerRepository;

        public TimersController(ITimerRepository timerRepository)
        {
            _timerRepository = timerRepository;
        }

        [HttpPost("SetTimer")]
        public async Task<IActionResult> SetTimer([FromBody] TimerRequest request)
        {
            var timer = new Timer(request.Hours, request.Minutes, request.Seconds, request.webhookUrl);

            await _timerRepository.AddTimerAsync(timer);

            return Ok(new { id = timer.Id });
        }

        [HttpGet("GetTimerStatus/{id}")]
        public async Task<IActionResult> GetTimerStatus(Guid id)
        {
            var timer = await _timerRepository.GetTimerByIdAsync(id);
            if (timer == null)
                return NotFound();

            var remainingTime = timer.ExpirationTime - DateTime.UtcNow;
            var remainingSeconds = remainingTime.TotalSeconds > 0 ? remainingTime.TotalSeconds : 0;

            return Ok(new { id, timeLeft = (int)remainingSeconds });
        }
    }
}
