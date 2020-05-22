using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class InstructerLogic
    {
        Context c;
        public InstructerLogic()
        {
            c = new Context();
        }
        public List<string> GetIns_Courses(string Name)
        {
            List<string> li = new List<string>();
            var v = from i in c.Instructer where i.InstructerName == Name select new { i.Course1, i.Course2, i.Course3, i.Course4 };
            foreach (var i in v)
            {
                li.Add(i.Course1);
                li.Add(i.Course2); li.Add(i.Course3); li.Add(i.Course4);
            }
            return li;
        }
        public List<Registration> GetSTDList(string Course)
        {
            List<Registration> li = new List<Registration>();
            var v = from i in c.Registration where i.Course == Course select new { i.Student, i.StudentID,i.FinalMark,i.FirstMark,i.SecondMark };
            foreach(var  i in v)
            {
                Registration r = new Registration();
                r.StudentID = i.StudentID;r.Student = i.Student;
                r.FirstMark = i.FirstMark;r.SecondMark = i.SecondMark;r.FinalMark = i.FinalMark;
                li.Add(r);
            }
            return li;
        }
        public List<Requests> GetRequests(string Name)
        {
            List<Requests> li = new List<Requests>();
            var v = from i in c.Requests where i.Instructer == Name select new { i.Student, i.ID, i.Time,i.Statue,i.CourseName,i.RegisteredStudents,i.Max};
            foreach (var i in v)
            {
                Requests r = new Requests();
                r.ID = i.ID; r.Student = i.Student;
                r.Time = i.Time;r.CourseName = i.CourseName;r.RegisteredStudents = i.RegisteredStudents;r.Max = i.Max;r.Statue = i.Statue;
                li.Add(r);
            }
            return li;
        }
        public void InsertMarks(string Student,string Course,string First,string Second,string Final)
        {
            Registration r = c.Registration.Single(x => ((x.Student == Student) && (x.Course == Course)));
            r.FirstMark = First;r.SecondMark = Second;r.FinalMark = Final;
            c.SaveChanges();
        }
        public void Approve(string Name ,string Course)
        {
            Closed cl = c.Closed.Single(x => x.Student == Name && x.Course == Course);
            cl.Statue = "Yes";
            c.SaveChanges();
        }
        public void Disapprove(string Name, string Course)
        {
            Closed cl = c.Closed.Single(x => x.Student == Name && x.Course == Course);
            cl.Statue = "No";
            c.SaveChanges();
        }
        public List<ComputerEngineering> GetExams(int ID)
        {
            List<ComputerEngineering> li = new List<ComputerEngineering>();
            var v = from i in c.ComputerEngineering where i.Instructer== ID select new { i.CourseName,i.FirstExam,i.SecondExam,i.FinalExam};
            foreach (var i in v)
            {
                ComputerEngineering co = new ComputerEngineering();
                co.CourseName = i.CourseName;co.FirstExam = i.FirstExam;co.SecondExam = i.SecondExam;co.FinalExam = i.FinalExam;
                li.Add(co);
            }
            return li;
        }
        public void ScheduleExam(string Name,string First,string Second,string Final)
        {
            ComputerEngineering co = c.ComputerEngineering.Single(x => x.CourseName == Name);
            co.FinalExam = Final;co.FirstExam = First;co.SecondExam = Second;
            c.SaveChanges();
        }
    }
}