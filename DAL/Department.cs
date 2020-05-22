using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { set; get; }
        public string DepartmentName { set; get; }
        public int Faculty { set; get; }
        [ForeignKey("ID")]
        public Faculty FacultyID { set; get; }
    }
}