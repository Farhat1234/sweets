using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class ApplyLeave
    {
        [DataMember]
        public int LeaveID { get; set;}
        
        [DataMember]
        public DateTime FromDate{ get; set; }

        [DataMember]
        public DateTime Todate { get; set; }

        [DataMember]
        public int NofDays { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public int LeaveTypeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
        
    }
}
