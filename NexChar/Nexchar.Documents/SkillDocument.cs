using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nexchar.Documents
{
    [DataContract]
   public  class SkillDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "skillKey")]
        public string SkillKey { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "rank")]
        public int Rank { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "type")]
        public string Type { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "baseAPCost")]
        public int BaseAPCost { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "classType")]
        public string ClassType { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "description")]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "bgpCost")]
        public int BGPCost { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "prereqs")]
        public List<PrereqDocument> Prereqs { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "prohibited")]
        public List<ProhitedDocument> Prohibited { get; set; }
    }
}
