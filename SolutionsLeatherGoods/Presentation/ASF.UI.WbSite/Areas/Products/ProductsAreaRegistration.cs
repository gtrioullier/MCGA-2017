using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Products
{
    public class ProductsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Products";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Products_default",
                "Products/{controller}/{action}/{Rowid}",
                new { action = "Index", Rowid = UrlParameter.Optional }
            );
        }
    }
}