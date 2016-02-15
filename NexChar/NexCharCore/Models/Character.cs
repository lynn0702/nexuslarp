using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using NexCharCore.Constants;

namespace NexCharCore.Models
{
    public class Character : IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        public string CharacterName { get; set; }
        public int Player_ID { get; set; }
        [ForeignKey("Player_ID")]
        public virtual Player Player { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int APTotal { get; set; }
        public int MPTotal { get; set; }
        public int SigTotal { get; set; }
        public int HitPoints { get; set; }
        [Required(ErrorMessage = "Chosen Class is required.")]
        public string ChosenClass { get; set; }
        public bool HasUsedChartDiscount { get; set; }
        public bool HasAppliedStartingRacials { get; set; }
        private List<OrganizationMembership> organizationMemberships { get; set; }
        public List<Organization> Organizations
        {
            get
            {
                return organizationMemberships.Select(x => x.Organization).ToList();
            }
        }

        public virtual List<CharacterSkill> CharacterSkills { get; set; }


        public void AddOrganization(Organization organization)
        {
            if (organizationMemberships != null && (organizationMemberships.Sum(x => x.Organization.Tier) + organization.Tier)<= 3)
            {
                organizationMemberships.Add(new OrganizationMembership { Character_ID = ID, Organization_Name = organization.Name });
            }
            else
            {
                organizationMemberships = new List<OrganizationMembership> {new OrganizationMembership { Character_ID = ID, Organization_Name = organization.Name }};                
            }
        }

        [NotMapped]
        private bool IsValidated { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IsValidated) { return results; }

            if (!Classes.CoreClasses.Contains(ChosenClass))
            {
                results.Add(new ValidationResult("Chosen Class is not recognized.", new[] { "ChosenClass" }));
            }

            if (results.Count == 0) { IsValidated = true; }
            return results;
        }

    }
}

