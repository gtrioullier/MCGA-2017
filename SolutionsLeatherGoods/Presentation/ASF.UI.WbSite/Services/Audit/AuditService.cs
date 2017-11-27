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
            _audit.date = System.DateTime.Today;
            _audit.user = HttpContext.Current.User.Identity.Name;
            return _audit;
        }

        public Boolean isAdmin()
        {
            try
            {
                var user = HttpContext.Current.User;

                if (user.IsInRole("Administrador"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Guid isClient(string aspnetuser)
        {
            try
            {
                var cp = new ASF.UI.Process.ClientProcess();

                var client = cp.SelectList().Where(c => c.AspNetUsers.ToLower() == aspnetuser).FirstOrDefault();

                if (client != null)
                {
                    return client.Rowid;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}