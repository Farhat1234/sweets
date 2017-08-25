using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
namespace HRMDAL.Entites
{
    [DataContract]
    public class StateCity
    {
        [DataMember]
        public int StateID { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public string CountryID { get; set; }
    }

    [DataContract]
    public class CountryStateCity
    {
        [DataMember]
        public int CountryID { get; set; }
        [DataMember]
        public string CountryName { get; set; }
    }

    [DataContract]
    public class City
    {
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public int StateID { get; set; }
    }

    [DataContract]
    public class Identity
    {
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int EmpID { get; set; }
    }
}