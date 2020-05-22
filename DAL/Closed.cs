using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Closed")]
    public class Closed
    {
        
       [Key]
        public int ArtificialKey { set; get; }
        public int ID { get; set; }
        public string Student { set; get; }
        public string Course { set; get; }
        public string Instructer { set; get; }
        public string Time { set; get; }
        public string Statue { set; get; }
        
    }
}