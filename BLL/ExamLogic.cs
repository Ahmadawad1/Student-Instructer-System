using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class ExamLogic
    {
        Context c;MarkRevision m;
        public ExamLogic()
        {
            m = new MarkRevision();
            c = new Context();
        }
        public List<Schedule> Schedule(int ID,string Major)
        {
            var MyCRS = from i in c.Registration.Where(x => x.StudentID == ID) select new { i.Course };
     
            List<Schedule> li = new List<Schedule>();
            List<string> MyCourses = new List<string>();
            foreach (var n in MyCRS)
            {
                MyCourses.Add(n.Course);
            }
            
                         foreach(var n in c.ComputerEngineering)
                            {
                                if (MyCourses.Contains(n.CourseName))
                            {
                                Schedule sc = new Schedule();
                                sc.Courses = n.CourseName;sc.First = n.FirstExam;
                                    sc.Second = n.SecondExam;sc.Final = n.FinalExam;
                                    li.Add(sc);
                                }

                            }
              
       
            return li; 
        }
        public List<Registration> Marks(int ID)
        {
            
            List<Registration> li = new List<Registration>();
            var MyCRS = from i in c.Registration.Where(x => x.StudentID == ID) select new { i.Course,i.FirstMark,i.SecondMark,i.FinalMark };
            foreach(var n in MyCRS)
            {
                Registration ri = new Registration();
                ri.Course = n.Course;ri.FirstMark = n.FirstMark;ri.SecondMark = n.SecondMark;ri.FinalMark = n.FinalMark;
                li.Add(ri);
            }
            return li;
        }
        public void ReviseMsg(int STDID,string STDN,string CRS,string Exam)
        {
            ComputerEngineeringV v = c.ComputerEngineeringV.Single(x => x.CourseName == CRS);
            m.CourseName = CRS;
            m.StudentID = STDID;m.StudentName = STDN;m.Exam = Exam;m.Instructer = v.InstructerName;
            c.MarkRevision.Add(m);
            c.SaveChanges();
        }

    }
}