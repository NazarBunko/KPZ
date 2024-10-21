using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Energy
{
    [DataContract]
    public class Counter
    {
        public Counter() { }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public MeterStatus Status { get; set; }
    }

    [DataContract]
    public enum MeterStatus
    {
        [EnumMember]
        Enabled,
        [EnumMember]
        Disabled
    }
}
