using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Login
    {
        public int EmployeeID { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public int? RoleID { get; set; }
    }
}
