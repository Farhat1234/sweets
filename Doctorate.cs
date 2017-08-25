using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Doctorate
    {
        [DataMember]
        public int DoctorateID { get; set; }

        [DataMember]
        public string DoctorateType { get; set; }
    }
}
