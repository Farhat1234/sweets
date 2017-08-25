using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class ApplyOnDuty
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }

        [DataMember]
        public string TypeOf { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string RmID { get; set; }
    }
}
