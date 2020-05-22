using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Instructers")]
    public class Instructers
    {
        [Key]
        public int ID { get; set; }
        public string InstructerName { set; get; }
       public int Department { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Course1 { set; get; }
        public string Course2 { set; get; }
        public string Course3 { set; get; }
        public string Course4 { set; get; }

    }
}