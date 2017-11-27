using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Services.Audit
{
    public static class Audit
    {
        public class auditObj
        {
            public string user { get; set; }
            public DateTime date { get; set; }
        }

        public static auditObj getAudit()
        {
            var auditService = DependencyResolver.Current.GetService<IAuditService>();
            var result = auditService.getAudit();
            return result;
        }

        public static Boolean isAdmin()
        {
            var auditService = DependencyResolver.Current.GetService<IAuditService>();
            var result = auditService.isAdmin();
            return result;
        }

        public static Guid isClient(string aspnetuser)
        {
            var auditService = DependencyResolver.Current.GetService<IAuditService>();
            var result = auditService.isClient(aspnetuser);
            return result;
        }

    }
}