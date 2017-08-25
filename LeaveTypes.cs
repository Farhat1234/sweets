using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class LeaveTypes
    {
        [DataMember]
        public int LeaveID { get; set; }

        [DataMember]
        public string LeaveType { get; set; }
    }
}
