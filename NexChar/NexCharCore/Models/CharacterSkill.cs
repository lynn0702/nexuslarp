using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class CharacterSkill
    {
        [Key]
        public int ID { get; set; }
        public int Character_ID { get; set; }
        [ForeignKey("Character_ID")]
        public virtual Character Character { get; set; }
        public string Skill_SkillKey { get; set; }
        [ForeignKey("Skill_SkillKey")]
        public virtual Skill Skill { get; set; }
        public DateTime DatePurchased { get; set; }
        [Range(0,100)]
        public int APSpent { get; set; }
        [Range(0.0, 100.0)]
        public decimal HitPointsEarned { get; set; }
    }
}
