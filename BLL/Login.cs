using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;

namespace BLL
{
    public class Login
    {
        Context c; string Msg;
        Student s;
       public Login()
        {
           Msg = string.Empty;
            c = new Context();
        }
        public virtual string Validation(string ID,string Password)
        {
            int i = Convert.ToInt32(ID);
            if (c.Students.SingleOrDefault(x => x.ID == i) == null) Msg = "Invalid ID No.!";
            else
            {
                s = c.Students.Single(x => x.ID == i);
                if (Password != s.Password) Msg = "Wrong Password!";
                else Msg = "OK"; 
            }
            return Msg;
        }
        public bool CheckIfNumber(string ID)
        {
            int v;
            if (Int32.TryParse(ID,out v)) return true;
            else return false;
        }
        public virtual string GetName(string ID)
        {
            int i = Convert.ToInt32(ID);
            s = c.Students.Single(x => x.ID == i);
            return s.FirstName + " " + s.SecondName;
        }
        public virtual string GetDep(string Name)
        {
            var v = from i in c.DEP_INS where i.InstructerName == Name select new { i.DepartmentName };
            string x=string.Empty;
            foreach(var i in v)
            {
                x = i.DepartmentName;
            }
            return x;
        }
        public int GetID(string Nm)
        {
            Instructers i = c.Instructer.Single(x => x.InstructerName == Nm);
            return i.ID;
        }
       


    }
}