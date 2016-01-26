using System.Runtime.Serialization;


namespace Nexchar.Documents
{
    [DataContract]
    public class PrereqDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "skillKey")]
        public string SkillKey { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "primaryRequirement")]
        public string PrimaryRequirement { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "secondaryRequirement")]
        public string SecondaryRequirement { get; set; }
    }
}
