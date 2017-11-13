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
    public partial class Language : EntityBase
    {
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Language Culture")]
        public string LanguageCulture { get; set; }

        [DataMember]
        [DisplayName("Flag Image File Name")]
        public string FlagImageFileName { get; set; }

        [DataMember]
        [DisplayName("Right To Left")]
        public bool RightToLeft { get; set; }

        public virtual IList<LocaleStringResource> LocaleStringResources { get; set; }
    }
}
