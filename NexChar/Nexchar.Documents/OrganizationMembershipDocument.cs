using System.Runtime.Serialization;

namespace Nexchar.Documents
{
    public class OrganizationMembershipDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "organization_Name")]
        public string Organization_Name { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "character_ID")]
        public int Character_ID { get; set; }

    }
}
