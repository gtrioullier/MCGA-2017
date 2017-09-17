using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.OrdersNumbers
{
    public class OrdersNumbersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrdersNumbers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrdersNumbers_default",
                "OrdersNumbers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}