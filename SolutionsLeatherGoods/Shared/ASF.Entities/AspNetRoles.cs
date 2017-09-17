using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace ASF.Entities
{
    [Serializable]
    [DataContract]
    public class AspNetRoles : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public string Id { get; set; }

        [DataMember]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
