using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nexchar.Documents
{
    [DataContract]
    public class ProhitedDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "skillKey")]
        public string SkillKey { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "prohibits")]
        public string Prohibits { get; set; }
    }
}
