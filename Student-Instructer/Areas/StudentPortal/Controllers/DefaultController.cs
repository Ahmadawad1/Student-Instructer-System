using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.StudentPortal.Controllers
{
    public class DefaultController : Controller
    {

        Login L = new Login();
        [HttpGet]
        public ActionResult Login()
        {
          
            Session["Error"] = string.Empty;
            Session["ID"]= null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            if (!L.CheckIfNumber(f[0]))
            {
                Session["Error"] = "Incorrect ID Format";
                return View();
            }
            else
            {
                if (L.Validation(f[0], f[1]) == "OK")
                { Session["ID"] = f[0]; Session["UserName"] = L.GetName(f[0]); return RedirectToAction("Profile", "Profile"); }
                else
                {
                    Session["Error"] = L.Validation(f[0], f[1]);
                    return View();
                }
            }

        }
        

    } }