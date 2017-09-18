using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsers
{
    public class AspsNetsUsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AspsNetsUsers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AspsNetsUsers_default",
                "AspsNetsUsers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}