using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class MsgLogic
    {
        Context c; CustomMsg cu;
        public MsgLogic()
        {
            cu = new CustomMsg();
            c = new Context();
        }
        public List<string> GetIns(int ID)
        {
            List<string> li = new List<string>();
            var r = from i in c.Registration where i.StudentID == ID select new { i.Instructer };
            foreach (var i in r)
            {
                li.Add(i.Instructer);
            }

            return li;
        }
        public List<string> GetCourses(int ID)
        {
            List<string> li = new List<string>();
            var r = from i in c.Registration where i.StudentID == ID select new { i.Course };
            foreach (var i in r)
            {
                li.Add(i.Course);
            }

            return li;
        }
        public void Send(int ID, string Std, string CRS, string Ins, string MSG)
        {
            cu.Course = CRS; cu.Message = MSG; cu.StudentID = ID; cu.StudentName = Std; cu.To = Ins;
            c.CustomMsg.Add(cu);
            c.SaveChanges();
        }
        public bool Check(string crs, string ins)
        {

            bool Result;
            ComputerEngineeringV v = c.ComputerEngineeringV.Single(x => x.CourseName == crs);
            if (v.InstructerName == ins) Result = true;
            else Result = false;
            return Result;
        }
        
        public GetAllMessages GetMSG(string Ins)
        {
            GetAllMessages g = new GetAllMessages();
            g.Custom = c.CustomMsg.Where(x => x.To==Ins).ToList();
            g.Revision=c.MarkRevision.Where(x => x.Instructer == Ins).ToList();
            return g;
        }
        public void DeleteMessage(string Name,string Course,int i)
        {
            if (i == 2)
            {
                CustomMsg m = c.CustomMsg.First(x => x.Course == Course && x.StudentName == Name);
                c.CustomMsg.Remove(m);
                c.SaveChanges();
            }
            else if(i == 1){
              MarkRevision m = c.MarkRevision.First(x => x.CourseName == Course && x.StudentName == Name);
                c.MarkRevision.Remove(m);
                c.SaveChanges();
            }
        }
        
    }
}