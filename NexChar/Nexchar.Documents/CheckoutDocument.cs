using System;
using System.Runtime.Serialization;


namespace Nexchar.Documents
{
    [DataContract]
    public class CheckoutDocument : IDocument
    {
        [DataMember(EmitDefaultValue = false, Name = "id")]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "character_id")]
        public int Character_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "event_id")]
        public int Event_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "sigsEarned")]
        public int SigsEarned { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "workTime")]
        public int WorkTime { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "nobleAlliedTo_id")]
        public int NobleAlliedTo_ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dateEntered")]
        public DateTime DateEntered { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "dateProcessed")]
        public DateTime? DateProcessed { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "isProcessed")]
        public bool IsProcessed { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "apormp")]
        public string APorMP { get; set; }
    }
}
