using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models.DAO
{
    public class Check
    {
        public static void Out()
        {
            if (HttpContext.Current.Session["loginSession"] == null) HttpContext.Current.Response.Redirect("/Admin/LoginAdmin");
        }

        public static bool isNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(s[i])) return false;
            return true;
        }
    }
}