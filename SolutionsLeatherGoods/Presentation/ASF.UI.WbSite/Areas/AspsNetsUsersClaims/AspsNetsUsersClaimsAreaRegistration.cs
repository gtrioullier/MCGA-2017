using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.AspsNetsUsersClaims
{
    public class AspsNetsUsersClaimsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AspsNetsUsersClaims";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AspsNetsUsersClaims_default",
                "AspsNetsUsersClaims/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}