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
    public class LocaleStringResource : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Resource Value")]
        public string ResourceValue { get; set; }

        [DataMember]
        [DisplayName("Locale Resource Key")]
        public int LocaleResourceKey_Id { get; set; }

        [DataMember]
        [DisplayName("Language")]
        public int Language_Id { get; set; }

        public virtual LocaleResourceKey LocaleResourceKey { get; set; }
        public virtual Language Language { get; set; }
    }
}
