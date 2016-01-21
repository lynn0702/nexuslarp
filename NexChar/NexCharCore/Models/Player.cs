using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public  class Player : IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VaultKey { get; set; }
        //1 = 30 minutes
        public int WorkTimeBank { get; set; }
        public int EEPTotal { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        public string EmailAddress { get; set; }

        [NotMapped]
        public string DisplayName {
            get { return FirstName + " " + LastName; }
        }

        [NotMapped]
        private bool IsValidated { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IsValidated) { return results; }

            ValidateEmailisOKOrBlank(results);

            if (results.Count == 0) { IsValidated = true; }
            return results;
        }


        private void ValidateEmailisOKOrBlank(List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(EmailAddress))
                return;

            foreach (var email in EmailAddress.Split(';'))
            {
                var trimmedEmail = email.Trim();
                if (!string.IsNullOrEmpty(trimmedEmail))
                {
                    if (trimmedEmail.Contains("@@") ||
                        trimmedEmail.Contains("..") ||
                        trimmedEmail.Contains("@.") ||
                        !trimmedEmail.Contains("@") ||
                        !trimmedEmail.Contains("."))
                    {
                        results.Add(new ValidationResult("An invalid Email Address was supplied.", new[] { "EmailAddress" }));
                        return;
                    }
                }
            }
        }
    }
}

