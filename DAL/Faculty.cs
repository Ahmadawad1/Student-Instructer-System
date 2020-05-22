using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Faculty")]
    public class Faculty
    {
       [Key]
       public int ID { set; get; }
        public string Name { set; get; }
    }
}