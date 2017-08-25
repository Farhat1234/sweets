using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Graduation
    {
        [DataMember]
        public int DegreeID { get; set; }

        [DataMember]
        public string DegreeType { get; set; }
    }
}
