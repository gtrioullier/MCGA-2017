using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASF.UI.WbSite.Services.Audit;

namespace ASF.UI.WbSite.Services.Audit
{
    public class AuditService : IAuditService
    {
        public Audit.auditObj getAudit()
        {
            var _audit = new Audit.auditObj();
            _audit.userId = 0;//todo: si agrego el campo, como lo traigo acá??
            _audit.date = System.DateTime.Today;
            _audit.user = HttpContext.Current.User.Identity.Name;
            return _audit;
        }
    }
}