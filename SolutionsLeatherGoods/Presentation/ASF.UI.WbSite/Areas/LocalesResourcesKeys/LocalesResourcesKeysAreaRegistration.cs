using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.LocalesResourcesKeys
{
    public class LocalesResourcesKeysAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LocalesResourcesKeys";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LocalesResourcesKeys_default",
                "LocalesResourcesKeys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}