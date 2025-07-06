using Microsoft.AspNetCore.Mvc;
using ScheduleService.Models;

namespace ScheduleService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public ScheduleController(ScheduleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            Console.WriteLine($"EVENT: schedule.created -> {schedule.Match}");
            return Ok(schedule);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Task.FromResult(_context.Schedules.ToList());
            return Ok(result);
        }
    }
}
