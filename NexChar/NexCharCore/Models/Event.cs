using System;
using System.ComponentModel.DataAnnotations;

namespace NexCharCore.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Location { get; set; }
        public int APBlanket { get; set; }
        public int MPBlanket { get; set; }
        public int BGPs { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
