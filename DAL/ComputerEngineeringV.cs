using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("ComputerEngineeringV")]
    public class ComputerEngineeringV
    {
        [Key]
        public int ID { set; get; }
        public string CourseName { set; get; }
        public string DepartmentName { set; get; }
        public string InstructerName { set; get; }
        public string Hall { set; get; }
        public string Time { set; get; }
        public string Day { set; get; }
        public int Max { set; get; }
        public string Statue { set; get; }

        public int RegisteredStudents { set; get; }
    }
}