using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public string DepartmentType { get; set; }
    }
}
