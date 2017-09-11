using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.OrdersDetails
{
    public class OrdersDetailsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrdersDetails";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrdersDetails_default",
                "OrdersDetails/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}