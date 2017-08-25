using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class EmployeeSearch
    {
        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public string EFname{ get; set; }
        [DataMember]
        public string Cname { get; set; }
        [DataMember]
        public DateTime DOJ { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Email { get; set; }
        
    }

    /// <summary>
    /// This class for editemploy table
    /// </summary>
    [DataContract]
    public class EmlpoyeeSeachEditEmp
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string Designation { get; set; }

        [DataMember]
        public string Dep { get; set; }

    }

}
