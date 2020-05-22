using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Web.UI.HtmlControls;

namespace Student_Instructer.Areas.StudentPortal.Controllers
{
    public class RegistrationController : Controller
    {       

        RegLogic r = new RegLogic();
        ProfileInfo p = new ProfileInfo();

        public ActionResult Registration()
        {
            if (Session["ID"] == null) return RedirectToAction("Login", "Default");
            else {  
                return View(r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
            }
        }
        private string UserMajor()
        {
            string Major;
            return Major = p.GetInfo(Session["ID"].ToString()).Major;     
        }
        private int UserID()
        {
            int ID;
            return ID= p.GetInfo(Session["ID"].ToString()).ID;
        }
        private string UserName()
        {
            string Name;
            return Name = p.GetInfo(Session["ID"].ToString()).FirstName + " " + p.GetInfo(Session["ID"].ToString()).SecondName;
        }
       
        [HttpGet]
        public ActionResult RegSystem()
        {
            if (Session["ID"] == null) return RedirectToAction("Login", "Default");
            return View("RegSystem", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
        [HttpGet]
        public ActionResult DeleteCourse()
        {
           
            return View("RegSystem", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
       
        [HttpPost]
       public ActionResult RegSystem(FormCollection f)
        {
            if (r.CheckClose(Convert.ToInt32(f["ID"]), UserID())==false) ViewBag.MSG = "The Course is Full !";
            else if (r.CheckRegistered(Convert.ToInt32(f["ID"]),UserID())) ViewBag.MSG = "The Course was Already Registered";
            else if (r.CheckTime(f["Time"],UserID())) ViewBag.MSG = "Time Disagree !";          
            else r.RegisterCourse(Convert.ToInt32(f["ID"]), f["Name"], f["Hall"], f["Time"], f["Day"], f["Ins"], UserID(), UserName());
            return View("RegSystem", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
        [HttpPost]
        public ActionResult DeleteCourse(FormCollection f)
        {
            int CourseID = Convert.ToInt32(f["ID1"]);
            r.DeleteCourse(CourseID, UserID());
            return View("RegSystem", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
        [HttpPost]
        public ActionResult Drop(string btn,string ID1)
        {
            if (btn == "Drop")
            {
                int CourseID = Convert.ToInt32(ID1);
                r.DeleteCourse(CourseID, UserID());
            }
            return View("Drop", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
        [HttpGet]
        public ActionResult Drop()
        {
            return View("Drop", r.SuggestedCourses_MyCourses(UserMajor(), UserID()));
        }
        [HttpGet]
        public ActionResult Closed()
        {
            return View("Closed", r.ClosedCourses_MyCourses(UserMajor(),UserID(),null));
        }
        [HttpPost]
        public ActionResult Closed(string btn, FormCollection f)
        { 
            if (btn == "Apply")
            {
                r.Apply(f["Course"], f["Instructer"], f["Time"], UserID(), UserName());
                f["search"] = null;
            }
            else if (btn == "Delete")
            {
                
                r.DeleteRequest(f["Course"], UserID());
                f["search"] = null;
            }
            else if(btn=="Submit"){

                if (r.CheckTime(f["Time"], UserID())) ViewBag.MSG = "Time Disagree !";
                else { r.RegisterClosed(f["Course"], f["Ti"], f["Ins"], UserID(), UserName());r.DeleteRequest(f["Course"], UserID()); }
                f["search"] = null;
            }

            return View("Closed", r.ClosedCourses_MyCourses(UserMajor(), UserID(), f["search"]));
        }

        public JsonResult GetS(string term)//Ajax Call
        {
            return Json(r.list(term), JsonRequestBehavior.AllowGet);
        }
    }
}