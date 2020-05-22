using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Student")]
    public class Student
    {
        
        [Key]
        public int ID { get; set; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string Email { set; get; }
        public string Major { set; get; }
        public string Password { set; get; }
        public string Image { set; get; }
        public int Department { set; get; }
        [ForeignKey("ID")]
        public Department DepartmentID { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { set; get; }
        
       
    }

}