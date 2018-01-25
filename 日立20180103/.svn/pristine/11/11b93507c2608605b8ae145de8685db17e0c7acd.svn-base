using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code001
{
    public class AreasCode001Registration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreasCode001";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreasCode001",
                "AreasCode001/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}