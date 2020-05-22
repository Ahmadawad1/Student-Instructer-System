using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data.SqlClient;
using System.Data.Entity;

namespace BLL
{
    public class RegLogic
    {
        Context c; Registration r;REG_STD RS;ComputerEngineering ce;Closed cl;
        public RegLogic()
        {
            c = new Context();RS = new REG_STD();cl = new Closed();
            r = new Registration();ce = new ComputerEngineering();
        }
        public REG_STD SuggestedCourses_MyCourses(string Major, int ID)
        {
                        RS.REG = c.ComputerEngineeringV.ToList();
            RS.STD = c.Registration.Where(x => x.StudentID == ID).ToList();
            RS.CLO = c.Closed.Where(x => x.ID == ID).ToList();
            return RS;
        }

        public REG_STD ClosedCourses_MyCourses(string Major, int ID,string search)
        {
                        if(search!=null)
                        RS.REG = c.ComputerEngineeringV.Where(x=>x.CourseName.StartsWith(search)).ToList();
                        else RS.REG = null;
            RS.CLO = c.Closed.Where(x => x.ID == ID).ToList();
            RS.STD = c.Registration.Where(x => x.StudentID == ID).ToList();
            return RS;
        }
        public void RegisterCourse(int CourseID,string Course,string Hall,string Time,string Day,string Ins,int StudentID,string Student)
        {
            ce = (ComputerEngineering)(c.ComputerEngineering.Single(x => x.ID == CourseID));
            ce.RegisteredStudents++;
            if (ce.RegisteredStudents == ce.Max) ce.Statue = "Closed";
                r.CourseID = CourseID;r.Course = Course;r.Hall = Hall;r.Day = Day;r.Instructer = Ins;r.StudentID = StudentID;r.Student = Student;r.Time = Time;
   c.Registration.Add(r);           
      c.SaveChanges();
        }
        public bool CheckClose(int CourseID, int StudentID)
        {
            bool x = false;
            ce = (ComputerEngineering)(c.ComputerEngineering.Single(y => y.ID == CourseID));
            if (ce.RegisteredStudents < ce.Max) { ce.Statue = "Open";c.SaveChanges(); return x = true; }
            else { ce.Statue = "Closed"; c.SaveChanges(); return x; }
        }
        public void DeleteCourse(int CourseID, int StudentID)
        {
           foreach(var i in c.Registration)
            {
                if (i.CourseID == CourseID && i.StudentID == StudentID) c.Registration.Remove(i);
            }
            if (ce.RegisteredStudents < ce.Max)ce.Statue = "Open";
                ce = (ComputerEngineering)(c.ComputerEngineering.Single(x => x.ID == CourseID));
            ce.RegisteredStudents--;
            c.SaveChanges();
        }

        public bool CheckRegistered(int ID,int StudentID)
        {
            bool x = false;
            foreach (var i in c.Registration)
            {
                if (i.CourseID == ID && i.StudentID==StudentID) { x=true; break; }    
            }
            return x;
        }
        public bool CheckTime(string Time,int ID)
        {
            bool x = false;
            foreach (var i in c.Registration.Where(y=>y.StudentID==ID))
            {
                if (i.Time == Time) { x = true; break; }
            }
            return x;
        }
       
        public List<string> list(string term)
        {
            List<string> li= c.ComputerEngineering.Where(y => y.CourseName.StartsWith(term)).Select(m=>m.CourseName).ToList();
            return li;
        }

        public void Apply(string Course,string Ins,string Time,int ID,string Name)
        {
            cl.ID = ID;cl.Instructer = Ins;cl.Student = Name;cl.Time = Time;cl.Statue = "Requesting";cl.Course = Course;
            c.Closed.Add(cl);
            c.SaveChanges();
        }
        public void DeleteRequest(string CRS , int StdID)
        {
            foreach (var i in c.Closed)
            {
                if ((i.Course == CRS )&& (i.ID== StdID)) c.Closed.Remove(i);
            }
           
            c.SaveChanges();
        }
        public void RegisterClosed(string CRS,string Time,string Ins,int ID,string Name)
        {
            ce = (ComputerEngineering)(c.ComputerEngineering.Single(x => x.CourseName== CRS));
            ce.RegisteredStudents++;
            if (ce.RegisteredStudents == ce.Max) ce.Statue = "Closed";
            r.CourseID = ce.ID; r.Course = CRS; r.Hall = ce.Hall; r.Day = ce.Day; r.Instructer = Ins; r.StudentID = ID; r.Student = Name; r.Time = Time;
            c.Registration.Add(r);
            c.SaveChanges();
        }
       

    }
}