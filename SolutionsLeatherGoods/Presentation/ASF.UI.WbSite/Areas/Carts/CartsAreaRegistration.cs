﻿using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.Carts
{
    public class CartsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Carts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Carts_default",
                "Carts/{controller}/{action}/{Rowid}",
                new { action = "Index", Rowid = UrlParameter.Optional }
            );
        }
    }
}