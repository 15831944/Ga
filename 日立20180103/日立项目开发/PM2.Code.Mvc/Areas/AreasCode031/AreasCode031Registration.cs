using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code031
{
    public class AreasCode031Registration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreasCode031";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreasCode031",
                "AreasCode031/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}