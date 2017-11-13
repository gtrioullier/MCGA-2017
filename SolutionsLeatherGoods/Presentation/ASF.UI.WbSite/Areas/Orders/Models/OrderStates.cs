using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASF.UI.WbSite.Areas.Orders.Models
{
    public enum OrderStates
    {
        Reviewed, 
        Suspended, 
        Closed, 
        Cancelled, 
        Approved
    }
}