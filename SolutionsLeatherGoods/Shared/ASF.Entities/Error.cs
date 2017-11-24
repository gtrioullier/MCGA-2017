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
    public partial class Error : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Client Id")]
        public int? ClientId { get; set; }
        
        [DataMember]
        [DisplayName("Error Date")]
        public DateTime? ErrorDate { get; set; }

        [DataMember]
        [DisplayName("Ip Address")]
        public string IpAddress { get; set; }

        [DataMember]
        [DisplayName("Client Agent")]
        public string ClientAgent { get; set; }

        [DataMember]
        [DisplayName("Exception")]
        public string Exception { get; set; }

        [DataMember]
        [DisplayName("Message")]
        public string Message { get; set; }

        [DataMember]
        [DisplayName("Everything")]
        public string Everything { get; set; }

        [DataMember]
        [DisplayName("HttpReferer")]
        public string HttpReferer { get; set; }

        [DataMember]
        [DisplayName("Path And Query")]
        public string PathAndQuery { get; set; }

    }
}
