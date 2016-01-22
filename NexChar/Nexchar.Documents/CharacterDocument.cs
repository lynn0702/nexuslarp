using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nexchar.Documents
{
    [DataContract]
    public class CharacterDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "characterName")]
        public string CharacterName { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "player_ID")]
        public int Player_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "playerDocument")]
        public PlayerDocument PlayerDocument { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "creationDate")]
        public DateTime CreationDate { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "lastUpdate")]
        public DateTime LastUpdate { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "apTotal")]
        public int APTotal { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "mpTotal")]
        public int MPTotal { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "sigTotal")]
        public int SigTotal { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "hitPoints")]
        public int HitPoints { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "chosenClass")]
        public string ChosenClass { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "hasUsedChartDiscount")]
        public bool HasUsedChartDiscount { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "hasAppliedStartingRacials")]
        public bool HasAppliedStartingRacials { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "organizationDocuments")]
        public List<OrganizationDocument> OrganizationDocuments{ get; set; }
        [DataMember(EmitDefaultValue = false, Name = "characterSkillDocuments")]
        public virtual IList<CharacterSkillDocument> CharacterSkillDocuments { get; set; }
    }
}
