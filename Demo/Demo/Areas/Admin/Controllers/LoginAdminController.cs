using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Areas.Admin.Models;
using Demo.Models.DAO;
using Demo.Models.DTO;

namespace Demo.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session["loginSession"] = null;
            return View();
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string UserName, string Password)
        {
            Session["currentPage"] = Request.Url.AbsoluteUri;
            AccountDTO account = new AccountDTO(UserName, Password);
            if (LoginAccount(UserName, Password))
            {
                Session["loginSession"] = UserName;
                return RedirectToAction("Index", "HomeAdmin");
            }
            else ModelState.AddModelError("", "UserName or Password not incorrect.");
            return View();
        }
        //public ActionResult Index(AccountModel account)
        //{
        //    if (LoginAccount(account.UserName, account.Password))
        //    {
        //        Session["loginSession"] = account.UserName;
        //        return RedirectToAction("Index", "HomeAdmin");
        //    }
        //    else ModelState.AddModelError("", "UserName or Password not incorrect.");
        //    return View();
        //}


        public ActionResult Logout()
        {
            Session["loginSession"] = null;
            return RedirectToAction("Index", "HomeAdmin");
        }
        bool LoginAccount(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
    }
}