using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.InstructerPortal.Controllers
{
    public class LoginController : Controller
    {
        Login L = new LoginInstructer();//Polymorphism
        [HttpGet]
        public ActionResult Login()
        {

            Session["Error"] = string.Empty;
            Session["Email"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {

            if (L.Validation(f[0], f[1]) == "OK")
            { Session["Email"] = f[0];Session["Dep"] = L.GetDep(L.GetName(f[0]));Session["Ins_ID"] = L.GetID(L.GetName(f[0])); Session["UserName"] = L.GetName(f[0]); return RedirectToAction("Courses", "Courses"); }
            else
            {
                Session["Error"] = L.Validation(f[0], f[1]);
                return View();
            }

        }
        
        

    }
}