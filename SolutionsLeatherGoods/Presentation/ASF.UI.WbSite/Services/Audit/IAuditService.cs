using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.UI.WbSite.Services.Audit;

namespace ASF.UI.WbSite.Services.Audit
{
    interface IAuditService
    {
        Audit.auditObj getAudit();
        Boolean isAdmin();
        Guid isClient(string aspnetuser);
    }
}
