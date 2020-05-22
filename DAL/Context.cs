using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class Context:DbContext
    {
      public Context():base("name=Context") { }
       public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<ComputerEngineeringV> ComputerEngineeringV { get; set; }
        public DbSet<ComputerEngineering> ComputerEngineering { get; set; }
        public DbSet<Closed> Closed { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<MarkRevision> MarkRevision { set; get; }
        public DbSet<Instructers> Instructer { set; get; }
        public DbSet<CustomMsg> CustomMsg { set; get; }
        public DbSet<DEP_INS> DEP_INS { set; get; }
        public DbSet<Requests> Requests { set; get; }
    }
}