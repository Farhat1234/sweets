using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    public class LoanDetails
    {
        [DataMember]
        public int LoanTypeId { get; set; }

        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string PrimaryApprover { get; set; }

        [DataMember]
        public string Note { get; set; }

        public string PayeeName { get; set; }
    }
}
