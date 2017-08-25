using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    public class IDProof
    {
        [DataMember]
        public string PAN { get; set; }

        [DataMember]
        public string PRAN { get; set; }

        [DataMember]
        public string Aadhar { get; set; }

        [DataMember]
        public string UAN { get; set; }

        [DataMember]
        public int EmpID { get; set; }

        public string DrivingLicense { get; set; }

        public string ESIC { get; set; }

        public string VoterID { get; set; }

        public string PFnumber { get; set; }
    }
}
