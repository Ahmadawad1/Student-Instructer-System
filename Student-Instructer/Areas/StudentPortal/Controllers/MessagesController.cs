using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace Student_Instructer.Areas.StudentPortal.Controllers
{
    public class MessagesController : Controller
    {
        MsgLogic m = new MsgLogic();
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
        public ActionResult Messages()
        {
            if (Session["ID"] == null) return RedirectToAction("Login", "Default");
            ViewBag.Ins = m.GetIns(UserID());
            ViewBag.Crs = m.GetCourses(UserID());
            
            return View();
        }
        [HttpPost]
        public ActionResult Messages(FormCollection f)
        {
            if ((f["Instructer"] != "Select Instructer" || f["Instructer"] !=null) && (f["Course"] != "Select Course" || f["Course"] != null )&& f["MSG"] != string.Empty) {

                if (m.Check(f["Course"], f["Instructer"]) == true)
                { m.Send(UserID(), UserName(), f["Course"], f["Instructer"], f["MSG"]); ViewBag.E = "Message was sent successfully"; }
                else ViewBag.E = "Incompatiple Instructer & Course !";
            } 
            else ViewBag.E = "Data are not specified !";
            ViewBag.Ins = m.GetIns(UserID());
            ViewBag.Crs = m.GetCourses(UserID());
            return View();
        }
        

    }
}