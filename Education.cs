using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    public class Education
    {
        [DataMember]
        public int EmpId { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public string Certificate { get; set; }

        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public string BranchStudyOne { get; set; }

        [DataMember]
        public string BranchStudyTwo { get; set; }

        [DataMember]
        public decimal Duration { get; set; }

        [DataMember]
        public string EducationalEstimation { get; set; }

        [DataMember]
        public string NameOfInstitute { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string AdditionalCourse { get; set; }

    }
}
