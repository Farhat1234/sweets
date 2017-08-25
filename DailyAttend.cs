using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
   public class DailyAttendance
    {
        [DataMember]
        public string EmpID { get; set; }

        [DataMember]
        public string EmpName { get; set; }
        
        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string InTime { get; set; }

        [DataMember]
        public string OutTime { get; set; }

        [DataMember]
        public string Leave { get; set; }
        
    }
}
