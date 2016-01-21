using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class OrganizationCheckoutRecord
    {
        [Key]
        public int ID { get; set; }
        public int Character_ID { get; set; }
        [ForeignKey("Character_ID")]
        public virtual Character Character { get; set; }
        public int Event_ID { get; set; }
        [ForeignKey("Event_ID")]
        public virtual Event Event { get; set; }
        public string Organization_Name { get; set; }
        [ForeignKey("Organization_Name")]
        public virtual Organization Organization { get; set; }
        public int FactionGain { get; set; }
        public int FactionSpent { get; set; }
        public int BountyTag { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime? DateProcessed { get; set; }
        public bool IsProcessed { get; set; }
    }
}
