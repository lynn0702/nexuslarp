using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nexchar.Documents
{
    [DataContract]
    public class LogisticsDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "characterID")]
        public int CharacterID { get; set; }
    }
}
