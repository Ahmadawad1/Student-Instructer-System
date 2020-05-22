using System.Web.Mvc;

namespace Student_Instructer.Areas.InstructerPortal
{
    public class InstructerPortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InstructerPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InstructerPortal_default",
                "InstructerPortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}