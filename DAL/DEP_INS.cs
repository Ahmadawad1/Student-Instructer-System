using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("DEP_INS")]
    public class DEP_INS
    {
        [Key]
        public string InstructerName { set; get; }
        public string DepartmentName { set; get; }

    }
}