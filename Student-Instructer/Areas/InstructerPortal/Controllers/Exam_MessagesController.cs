using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.InstructerPortal.Controllers
{
    public class Exam_MessagesController : Controller
    {
        InstructerLogic i = new InstructerLogic();
        MsgLogic m = new MsgLogic();
        [HttpGet]
        public ActionResult Exams()
        {
            if (Session["Email"] == null) return RedirectToAction("Login", "Login");
            return View(i.GetExams(Convert.ToInt32(Session["Ins_ID"])));
        }
        [HttpPost]
        public ActionResult Exams(FormCollection f)
        {
            i.ScheduleExam(f["Name"],f["First"],f["Second"],f["Final"]);
            return View(i.GetExams(Convert.ToInt32(Session["Ins_ID"])));
        }
        [HttpGet]
        public ActionResult Messages()
        {
            return View(m.GetMSG(Session["UserName"].ToString()));
        }
        [HttpPost]
        public ActionResult Messages(FormCollection f,string btn)
        {
            if (btn == "2")
            {
                m.DeleteMessage(f["STD2"], f["CRS2"], 2);
            }
            else if (btn == "1")
            {
                m.DeleteMessage(f["STD"], f["CRS"], 1);
            }
            return View(m.GetMSG(Session["UserName"].ToString()));
        }
    }
}