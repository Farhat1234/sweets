using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class PaySlip
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public string CompName { get; set; }

        [DataMember]
        public string  Designation { get; set; }

        [DataMember]
        public decimal ProfessionTax { get; set; }

        [DataMember]
        public decimal PreviousSalary { get; set; }

        [DataMember]
        public decimal CurrentSalary { get; set; }

        [DataMember]
        public decimal NetSalary { get; set; }

        [DataMember]
        public int Increment { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public int Child { get; set; }

        public string InterimRelief { get; set; }

    }
}
