using System.Runtime.Serialization;

namespace Nexchar.Documents
{
    [DataContract]
    public class OrganizationDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "tier")]
        public int Tier { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "abbreviation")]
        public string Abbreviation { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "type")]
        public string Type { get; set; }
    }
}
