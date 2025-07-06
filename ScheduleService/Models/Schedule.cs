using System;

namespace ScheduleService.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Match { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
    }
}
