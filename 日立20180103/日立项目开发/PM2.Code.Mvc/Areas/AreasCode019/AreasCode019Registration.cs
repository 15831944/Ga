using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code019
{
    public class AreasCode019Registration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreasCode019";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreasCode019",
                "AreasCode019/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}