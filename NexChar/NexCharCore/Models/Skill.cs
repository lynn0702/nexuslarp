using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NexCharCore.Constants;

namespace NexCharCore.Models
{
    public class Skill : IValidatableObject
    {
        //Name + " " + "Rank " + Rank.toString()
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Computed)]
        public string SkillKey { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Rank { get; set; }

        public string Type { get; set; }

        [Range(0, 100)]
        public int BaseAPCost { get; set; }

        public string ClassType { get; set; }
        public string Description { get; set; }

        [Range(0, 120)]
        public int BGPCost { get; set; }

        [ForeignKey("Skill_SkillKey")]
        public IList<PrerequisiteSkill> Prereqs { get; set; }

        [ForeignKey("Skill_SkillKey")]
        public IList<ProhibitedSkill> Prohibited { get; set; }
            
        [NotMapped]
        private bool IsValidated { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IsValidated)
            {
                return results;
            }

            if (!SkillTypes.AllTypes.Contains(Type))
            {
                results.Add(new ValidationResult("Type is not recognized.", new[] {"Type"}));
            }

            if (!Classes.AllClassTypes.Contains(ClassType))
            {
                results.Add(new ValidationResult("ClassType is not recognized.", new[] { "ClassType" }));
            }

            if (results.Count == 0)
            {
                IsValidated = true;
            }
            return results;
        }
    }
}