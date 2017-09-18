using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.LocalesStringsResources
{
    public class LocalesStringsResourcesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LocalesStringsResources";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LocalesStringsResources_default",
                "LocalesStringsResources/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}