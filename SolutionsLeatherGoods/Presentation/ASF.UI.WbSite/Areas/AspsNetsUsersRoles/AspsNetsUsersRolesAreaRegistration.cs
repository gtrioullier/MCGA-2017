using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersRoles
{
    public class AspsNetsUsersRolesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AspsNetsUsersRoles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AspsNetsUsersRoles_default",
                "AspsNetsUsersRoles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}