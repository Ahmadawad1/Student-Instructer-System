using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]//cs,ef assumes that my col is identity,hence it tries to insert null
        public int ArtificialKey { set; get; }
        public int StudentID { set; get; }
        public string Student { set; get; }
        public string Course { set; get; }
        public string Time { set; get; }
        public string Hall { set; get; }
        public string Instructer { set; get; }
        public int CourseID { set; get; }
        public string Day { set; get; }
        public string FirstMark { set; get; }
        public string SecondMark { set; get; }
        public string FinalMark { set; get; }
    }
}