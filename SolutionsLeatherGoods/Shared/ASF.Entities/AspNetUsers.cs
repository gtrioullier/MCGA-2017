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
    public partial class AspNetUsers : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public string Id { get; set; }

        [DataMember]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [DataMember]
        [DisplayName("Password Hash")]
        public string PasswordHash { get; set; }

        [DataMember]
        [DisplayName("Security Stamp")]
        public string SecurityStamp { get; set; }

        [DataMember]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DataMember]
        [DisplayName("Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [DataMember]
        [DisplayName("Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        [DataMember]
        [DisplayName("Lockout End Date UTC")]
        public DateTime? LockoutEndDateUtc { get; set; }

        [DataMember]
        [DisplayName("Lockout Enabled")]
        public bool LockoutEnabled { get; set; }

        [DataMember]
        [DisplayName("Access Failed Count")]
        public int AccessFailedCount { get; set; }

        [DataMember]
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}
