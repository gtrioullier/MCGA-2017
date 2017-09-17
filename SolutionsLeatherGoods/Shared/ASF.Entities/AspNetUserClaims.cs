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
    public class AspNetUserClaims : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("User Id")]
        public string UserId { get; set; }

        [DataMember]
        [DisplayName("Claim Type")]
        public string? ClaimType { get; set; }

        [DataMember]
        [DisplayName("Claim Value")]
        public string? ClaimValue { get; set; }

    }
}
