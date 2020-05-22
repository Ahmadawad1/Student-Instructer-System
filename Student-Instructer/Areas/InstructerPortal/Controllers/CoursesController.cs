using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.InstructerPortal.Controllers
{
    public class CoursesController : Controller
    {
        InstructerLogic i = new InstructerLogic();
        [HttpGet]
        public ActionResult Courses()
        {
            if (Session["Email"] == null) return RedirectToAction("Login","Login");
            ViewBag.Courses = i.GetIns_Courses(Session["UserName"].ToString());
            return View();
        }
        [HttpGet]
        public ActionResult ClosedCourses()
        {  
            return View("ClosedCourses",i.GetRequests(Session["UserName"].ToString()));
        }
        [HttpPost]
        public ActionResult ClosedCourses(string btn,FormCollection f)
        {
            if (btn == "Approve") { i.Approve(f["STD"], f["CRS"]); }
            else if (btn == "Disapprove") { i.Disapprove(f["STD"], f["CRS"]); }
            return View("ClosedCourses", i.GetRequests(Session["UserName"].ToString()));
        }
        [HttpPost]
        public ActionResult Courses(string btn)
        {
            Session["SelectedCourse"] = btn;
            return View("STDList", i.GetSTDList(Session["SelectedCourse"].ToString()));
        }
        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            i.InsertMarks(f["Name"],Session["SelectedCourse"].ToString(),f["First"], f["Second"], f["Final"]);
            return View("STDList", i.GetSTDList(Session["SelectedCourse"].ToString()));
        }
        

    }
}