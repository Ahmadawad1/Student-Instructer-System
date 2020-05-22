using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Requests")]
    public class Requests
    {
        [Key]
        public int ID { set; get; }
        public string CourseName { set; get; }
        public string Student { set; get; }
        public string Time { set; get; }
        public string Instructer { set; get; }
        public int RegisteredStudents { set; get; }
        public string Statue { set; get; }
        public int Max { set; get; }
    }
}