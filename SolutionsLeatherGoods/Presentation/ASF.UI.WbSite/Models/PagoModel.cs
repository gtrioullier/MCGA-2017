using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASF.UI.WbSite.Models
{
    public class PagoModel
    {
        [Range(0, double.MaxValue)]
        public double Importe { get; set; }

        public int cvc { get; set; }

        public string number { get; set; }

        public string expiry { get; set; }

        public string name { get; set; }

        public Guid rowid { get; set; }
    }
}