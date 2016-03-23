using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nexchar.Documents
{
    //TODO Complete
    [DataContract]
    public class PlayerDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "vaultKey")]
        public string VaultKey { get; set; }
        //1 = 30 minutes
        [DataMember(EmitDefaultValue = false, Name = "workTimeBank")]
        public int WorkTimeBank { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "eepTotal")]
        public int EEPTotal { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "emailAddress")]
        public string EmailAddress { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "displayName")]
        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
