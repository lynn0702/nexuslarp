using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class CharacterCheckoutRecord
    {
        [Key]
        public int ID { get; set; }
        public int Character_ID { get; set; }
        [ForeignKey("Character_ID")]
        public virtual Character Character { get; set; }
        public int Event_ID { get; set; }
        [ForeignKey("Event_ID")]
        public virtual Event Event { get; set; }
        public int SigsEarned { get; set; }
        public int WorkTime { get; set; }
        public int NobleAlliedTo_ID { get; set; }
        [ForeignKey("NobleAlliedTo_ID")]
        public virtual Character NobleAlliedTo { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime? DateProcessed { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsAPGain { get; set; }
        public bool IsMPGain { get; set; }

        [NotMapped]
        public string APorMP
        {
            get { return IsAPGain ? "AP" : IsMPGain ? "MP" : "No Gain"; }
            set
            {
                switch (value)
                {
                    case "AP":
                        IsAPGain = true;
                        IsMPGain = false;
                        break;
                    case "MP":
                        IsAPGain = false;
                        IsMPGain = true;
                        break;
                    case"No Gain":
                        IsAPGain = false;
                        IsMPGain = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
