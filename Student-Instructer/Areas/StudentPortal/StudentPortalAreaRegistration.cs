using System.Web.Mvc;

namespace Student_Instructer.Areas.StudentPortal
{
    public class StudentPortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "StudentPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "StudentPortal_default",
                "StudentPortal/{controller}/{action}/{id}",
                new { action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}