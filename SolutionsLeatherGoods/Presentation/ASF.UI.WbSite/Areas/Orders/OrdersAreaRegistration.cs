using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Orders
{
    public class OrdersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Orders";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Orders_default",
                "Orders/{controller}/{action}/{Rowid}",
                new { action = "Index", Rowid = UrlParameter.Optional }
            );
        }
    }
}