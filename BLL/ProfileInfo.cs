using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.IO;

namespace BLL
{
    public class ProfileInfo
    {
        Context c;Algorithm a;
        Student s;
        public ProfileInfo()
        {
            c = new Context();
            a = new Algorithm();
        }

        public Student GetInfo(string ID)
        {
            int i = Convert.ToInt32(ID);
             s =c.Students.Single(x=>x.ID==i);
            return s;
        }
        public string ChangePassword(string ID,string Current,string New ,string Confirm)
        {
            if (GetInfo(ID).Password != Current) return "Wrong Old Password";
            else
            {
                if (New != Confirm) return "Non-Compatible Password";
                else
                {
                    if (New.Length < 8) return "Password should be at least 8 character!";
                    else
                    {
                        GetInfo(ID).Password = New;
                        c.SaveChanges();
                        return "OK";
                    }
                }
            }

        }
        public void ChangeEmail(string ID,string Email)
        {
            GetInfo(ID).Email = Email;
            c.SaveChanges();
                    }

        public void ChangeImage(string ID, string FileName)
        {
           
            if (FileName != null)
            {
                string Extension = Path.GetExtension(FileName);
                if (a.LinearSearch(Extension))
                {
                    string Path = "~/Images/" + FileName;
                    GetInfo(ID).Image = Path;
                    c.SaveChanges();
                }
            }
        }
        

    }
}