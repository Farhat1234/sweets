using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class NotInOffice
    {
        [DataMember]
        public int NIOID { get; set; }

        [DataMember]
        public string NIOType { get; set; }
    }
}
