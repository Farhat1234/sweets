using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{
    [DataContract]
    public class Relation
    {
        [DataMember]
        public int RelationID { get; set; }

        [DataMember]
        public string RelationType { get; set; }
    }
}
