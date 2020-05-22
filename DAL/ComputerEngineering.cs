using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("ComputerEngineering")]
    public class ComputerEngineering
    {
        [Key] 
        public int ID { set; get; }
        public string CourseName { set; get; }
        public string Hall { set; get; }
        public string Time { set; get; }
        public string Day { set; get; }
        public int Department { set; get; }
        public int Instructer { set; get; }
        public string Statue { set; get; }
        public int RegisteredStudents { set; get; }
        public int Max { set; get; }
        public string FirstExam { set; get; }
        public string SecondExam { set; get; }
        public string FinalExam { set; get; }
        [ForeignKey("ID")]
        public Department DepartmentID { set; get; }
        [ForeignKey("ID")]
        public Instructers InstructerID { set; get; }


    }
}