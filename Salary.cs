using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Salary
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public string Month { get; set; }

        [DataMember]
        public string Year { get; set; }

        [DataMember]
        public string CompName { get; set; }

        [DataMember]
        public string CurrSalary { get; set; }

    }
}
