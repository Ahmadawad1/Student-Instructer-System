using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("CustomMsg")]
    public class CustomMsg
    {
        [Key]
        public int MSGID { set; get; }
        public int StudentID { set; get; }
        public string StudentName { set; get; }
        public string Course { set; get; }
        public string To { set; get; }
 public string Message { set; get; }
    }
}