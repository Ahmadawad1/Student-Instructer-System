using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class LoginInstructer:Login
    {
        Context c; string Msg;
        Instructers s;
        public LoginInstructer()
        {
            Msg = string.Empty;
            c = new Context();
        }
        public override string Validation(string Email, string Password)
        {
            
            if (c.Instructer.SingleOrDefault(x => x.Email == Email) == null) Msg = "Invalid Email!";
            else
            {
                s = c.Instructer.Single(x => x.Email == Email);
                if (Password != s.Password) Msg = "Wrong Password!";
                else Msg = "OK";
            }
            return Msg;
        }
        public override string GetName(string Email)
        {
            s = c.Instructer.Single(x => x.Email == Email);
            return s.InstructerName;
        }
        public override string GetDep(string Name)
        {
            var v = from i in c.DEP_INS where i.InstructerName == Name select new { i.DepartmentName };
            string x = string.Empty;
            foreach (var i in v)
            {
                x = i.DepartmentName;
            }
            return x;
        }
       

    }
}