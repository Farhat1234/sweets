using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    public class Passport
    {
        [DataMember]
        public int EmpID { get; set; }

        [DataMember]
        public string PassportFor { get; set; }

        [DataMember ]
        public string Name { get; set; }

        [DataMember]
        public string GivenName { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public DateTime DateofBirth { get; set; }

        [DataMember]
        public string PlaceofBirth { get; set; }

        [DataMember]
        public string  Nationality { get; set; }

        [DataMember]
        public string PassportIssuingCountry { get; set; }

        [DataMember]
        public int PassportNo { get; set; }

        [DataMember]
        public DateTime IssueDate { get; set; }

        [DataMember]
        public DateTime ExpiryDate { get; set; }

        [DataMember]
        public string PlaceofIssue { get; set; }

        [DataMember]
        public string RenewalApplied { get; set; }

    }
}
