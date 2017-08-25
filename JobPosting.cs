using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class JobPosting
    {
        [DataMember]
        public int JobID { get; set; }
        [DataMember]
        public string JobDomain { get; set; }
        [DataMember]
        public string JobTitle { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Skills { get; set; }
        [DataMember]
        public string Expierence { get; set; }
        [DataMember]
        public string Qualification { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public int NofEmp { get; set; }
        [DataMember]
        public int EmpID { get; set; }
    }
}
