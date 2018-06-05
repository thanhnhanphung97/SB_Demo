using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models.DAO;
using Demo.Models.DTO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View();
        }

        //[HttpPost, ActionName("Index")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DetailsConfirmed(int id)
        //{
        //    news news = db.news.Find(id);
        //    return View(news);
        //}

    }

}