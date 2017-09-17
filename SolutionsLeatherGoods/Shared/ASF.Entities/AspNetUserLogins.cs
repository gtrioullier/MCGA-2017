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
    public class AspNetUserLogins : EntityBase
    {
        [DataMember]
        [DisplayName("Login Provider")]
        public string LoginProvider { get; set; }

        [DataMember]
        [DisplayName("Provider Key")]
        public string ProviderKey { get; set; }

        [DataMember]
        [DisplayName("User Id")]
        public string UserId { get; set; }
    }
}
