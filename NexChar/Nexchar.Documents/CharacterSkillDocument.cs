using System;
using System.Runtime.Serialization;

namespace Nexchar.Documents
{
    //TODO Complete
    [DataContract]
    public class CharacterSkillDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "character_id")]
        public int Character_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "skill_SkillKey")]
        public string Skill_SkillKey { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "datePurchased")]
        public DateTime DatePurchased { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "apSpent")]
        public int APSpent { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "hitPointsEarned")]
        public decimal HitPointsEarned { get; set; }
    }
}
