using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
   public class FavoredSkill
    {
        [Key]
        public int ID { get; set; }
        public string Skill_SkillKey { get; set; }
        [ForeignKey("Skill_SkillKey")]
        public virtual Skill Skill { get; set; }
        public string Favors_SkillKey { get; set; }
        [ForeignKey("Favors_SkillKey")]
        public virtual Skill FavorsSkill { get; set; }
        [Range(-100, 100)]
        public int APReduction { get; set; }

    }
}