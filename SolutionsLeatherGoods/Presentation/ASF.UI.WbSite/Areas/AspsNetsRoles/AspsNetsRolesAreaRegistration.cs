using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsRoles
{
    public class AspsNetsRolesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AspsNetsRoles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AspsNetsRoles_default",
                "AspsNetsRoles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}