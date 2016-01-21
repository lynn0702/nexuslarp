using System.ComponentModel.DataAnnotations.Schema;

namespace NexCharCore.Models
{
    public class OrganizationMembership
    {
        public int ID { get; set; }
        public string Organization_Name { get; set; }
        [ForeignKey("Organization_Name")]
        public virtual Organization  Organization{ get; set; }
        public int Character_ID { get; set; }
        [ForeignKey("Character_ID")]
        public virtual Character Character { get; set; }
    }
}
