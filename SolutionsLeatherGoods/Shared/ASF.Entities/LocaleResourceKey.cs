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
    public class LocaleResourceKey : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Notes")]
        public string? Notes { get; set; }

        [DataMember]
        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
