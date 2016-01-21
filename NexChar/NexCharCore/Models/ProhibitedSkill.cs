using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class ProhibitedSkill
    {
        [Key]
        public int ID { get; set; }
        public string Skill_SkillKey { get; set; }
        [ForeignKey("Skill_SkillKey")]
        public virtual Skill Skill { get; set; }
        public string Prohibits_SkillKey { get; set; }
        [ForeignKey("Prohibits_SkillKey")]
        public virtual Skill ProhibitsSkill { get; set; }

    }
}
