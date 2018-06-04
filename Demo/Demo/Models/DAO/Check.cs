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
    }
}