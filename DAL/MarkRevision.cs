using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("MarkRevision")]
    public class MarkRevision
    {
        [Key]
        public int MSGID { set; get; }
        public int StudentID { set; get; }
        public string StudentName { set; get; }
        public string CourseName { set; get; }
        public string Instructer { set; get; }
        public string Exam {set;get;}
    }
}