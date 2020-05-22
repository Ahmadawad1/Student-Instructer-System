using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
namespace Student_Instructer.Areas.StudentPortal.Controllers
{
    public class ProfileController : Controller
    {
        // GET: StudentPortal/Profile

        ProfileInfo p = new ProfileInfo();
        public new ActionResult Profile()
        {
            if (Session["ID"] == null) return RedirectToAction("Login", "Default");
            else return View(p.GetInfo(Session["ID"].ToString()));
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection f)
        {
            ViewBag.Password = p.ChangePassword(Session["ID"].ToString(), f[0], f[1], f[2]);
            if (ViewBag.Password == "OK")
                return RedirectToAction("Profile");
            else return View("ChangePassword","MasterView",ViewBag.Password);
        }
        [HttpGet]
        public ActionResult ChangeEmail()
        {
            return View(p.GetInfo(Session["ID"].ToString()));
        }
        [HttpPost]
        public ActionResult ChangeEmail(FormCollection f)
        {
            p.ChangeEmail(Session["ID"].ToString(), f[1]);
                return RedirectToAction("Profile");
        }
        [HttpGet]
        public ActionResult ChangeImage()
        {
            return View(p.GetInfo(Session["ID"].ToString()));
        }
        [HttpPost]
        public ActionResult ChangeImage(HttpPostedFileBase file)
        {
            
            p.ChangeImage(Session["ID"].ToString(), file.FileName);
            return RedirectToAction("Profile");
        }
    }
}