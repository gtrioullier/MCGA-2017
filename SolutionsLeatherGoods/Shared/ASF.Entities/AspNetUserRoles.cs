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
    public class AspNetUserRoles : EntityBase
    {
        [DataMember]
        [DisplayName("User Id")]
        public string UserId { get; set; }

        [DataMember]
        [DisplayName("Role Id")]
        public string RoleId { get; set; }
    }
}
