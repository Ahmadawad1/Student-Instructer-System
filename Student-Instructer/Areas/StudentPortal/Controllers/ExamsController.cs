using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.StudentPortal.Controllers
{
    public class ExamsController : Controller
    {
        ExamLogic e = new ExamLogic();
        ProfileInfo p = new ProfileInfo();
        private string UserMajor()
        {
            string Major;
            return Major = p.GetInfo(Session["ID"].ToString()).Major;
        }
        private int UserID()
        {
            int ID;
            return ID = p.GetInfo(Session["ID"].ToString()).ID;
        }
        private string UserName()
        {
            string Name;
            return Name = p.GetInfo(Session["ID"].ToString()).FirstName + " " + p.GetInfo(Session["ID"].ToString()).SecondName;
        }
        [HttpGet]
        public ActionResult Exams()
        {
            if (Session["ID"] == null) return RedirectToAction("Login", "Default");
            return View(e.Schedule(UserID(),UserMajor()));
        }
        [HttpGet]
        public ActionResult Marks()
        {
            return View(e.Marks(UserID()));
        }
        [HttpGet]
        public ActionResult Revise()
        {
            return View(e.Marks(UserID()));
        }
        [HttpPost]
        public ActionResult Revise(FormCollection f)
        {
            if (f["Course"] == "Select Course" || f["Course"]==null) ViewBag.Error = "Choose the Course";
            else if (f["Exam"] == "Select Exam" || f["Exam"] == null) ViewBag.Error = "Choose the Exam";
            else
            e.ReviseMsg(UserID(),UserName(),f["Course"],f["Exam"]);
            return View(e.Marks(UserID()));
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}