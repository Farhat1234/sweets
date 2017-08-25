using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime DOJ { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public decimal Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }

        [DataMember]
        public byte[] Resume { get; set; }

        [DataMember]
        public int Designation { get; set; }

        [DataMember]
        public string PAddress { get; set; }

        [DataMember]
        public string PCity { get; set; }

        [DataMember]
        public string PCountry { get; set; }

        [DataMember]
        public string CCountry { get; set; }

        [DataMember]
        public string PState { get; set; }

        [DataMember]
        public string CAddress { get; set; }

        [DataMember]
        public string CCity { get; set; }

        [DataMember]
        public string CState { get; set; }

        [DataMember]
        public string PreviousCompany { get; set; }

        [DataMember]
        public string PreviousDesignation { get; set; }

        [DataMember]
        public string PreviousContactPerson { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string BloodGroup { get; set; }

        [DataMember]
        public string ReportingManager { get; set; }

        [DataMember]
        public decimal PreviousContactNumber { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public DateTime ToDate { get; set; }

        public string Password { get; set; }

        public string Desig { get; set; }

        public string Role { get; set; }
    }
}
