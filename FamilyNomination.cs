using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    public class FamilyNomination
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string Relation { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Initials { get; set; }

        [DataMember]
        public string NameatBirth { get; set; }

        [DataMember]
        public DateTime DateofBirth { get; set; }

        [DataMember]
        public string PlaceofBirth { get; set; }

        [DataMember]
        public string BirthCountry { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public decimal Phone { get; set; }

        [DataMember]
        public string Address { get; set; }

    }
}
