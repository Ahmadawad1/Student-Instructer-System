using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Algorithm
    {

        public bool LinearSearch(string Extension)
        {
            string[] arr = { ".pdf", ".jpg", ".jpeg" };
            bool found =false ;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == Extension) found = true;
            }
            return found;
        }

    }
}