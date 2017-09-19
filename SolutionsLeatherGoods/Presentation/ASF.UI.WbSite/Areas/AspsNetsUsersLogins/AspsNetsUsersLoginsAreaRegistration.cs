using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersLogins
{
    public class AspsNetsUsersLoginsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AspsNetsUsersLogins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AspsNetsUsersLogins_default",
                "AspsNetsUsersLogins/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}