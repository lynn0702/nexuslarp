using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NexCharCore.Constants;

namespace NexCharCore.Models
{
    public class Organization : IValidatableObject
    {
        [Key,MaxLength(80)]
        public string Name { get; set; }
        [Range(0,3)]
        public int Tier { get; set; }
        [MaxLength(5)]
        public string Abbreviation { get; set; }
        public string Type { get; set; }

        [NotMapped]
        private bool IsValidated { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IsValidated) { return results; }

            if (!OrganizationTypes.AllTypes.Contains(Type))
            {
                results.Add(new ValidationResult("Type is not recognized.", new[] { "Type" }));
            }

            if (results.Count == 0) { IsValidated = true; }
            return results;
        }
    }
}
