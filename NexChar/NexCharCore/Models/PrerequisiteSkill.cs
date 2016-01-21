using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class PrerequisiteSkill
    {
        [Key]
        public int ID { get; set; }
        public string Skill_SkillKey { get; set; }
        [ForeignKey("Skill_SkillKey")]
        public virtual Skill Skill { get; set; }
        public string PrimaryRequirement_SkillKey { get; set; }
        [ForeignKey("PrimaryRequirement_SkillKey")]
        public virtual Skill PrimaryRequirement { get; set; }
        public string SecondaryRequirement_SkillKey { get; set; }
        [ForeignKey("SecondaryRequirement_SkillKey")]
        public virtual Skill SecondaryRequirement { get; set; }
    }
}
