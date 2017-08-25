using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace HRMDAL.Entites
{

    [DataContract]
    public class PostGraduation
    {
        [DataMember]
        public int PGID { get; set; }

        [DataMember]
        public string PGType { get; set; }
    }
}
