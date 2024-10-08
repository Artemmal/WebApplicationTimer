using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationTimer.Models
{
    public class TimerRequest
    {
        [Range(0, int.MaxValue)]
        public int Hours { get; set; }

        [Range(0, 59)]
        public int Minutes { get; set; }

        [Range(0, 59)]
        public int Seconds { get; set; }

        [Required]
        public string webhookUrl { get; set; }
    }
}
