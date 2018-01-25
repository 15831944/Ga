using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030
{
    public class AreasCode030Registration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreasCode030";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreasCode030",
                "AreasCode030/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}