using Demo.Models.DAO;
using Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo.Areas.Admin.Controllers
{
    public class NewsAdminController : Controller
    {
        // GET: Admin/Introduces
        public ActionResult Index()
        { 
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            List<NewsDTO> list = NewsDAO.Instance.GetListNews();
            return View(list.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View();
        }

        [HttpPost,ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name,string Img,string Describe,string Link)
        {
            if (NewsDAO.Instance.InsertNews(Name, Img, Describe, Link))
            {
                return RedirectToAction("Index", "NewsAdmin");
            }
            else return View();
        }
        
        public ActionResult Edit(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            NewsDTO intro = NewsDAO.Instance.GetNews(int.Parse(Id));
            if (intro == null)
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View(intro);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string Name, string Img, string Describe, string Link)
        {
            if(NewsDAO.Instance.EditNews(Id, Name, Img, Describe, Link))
            {
                return RedirectToAction("Index", "NewsAdmin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            NewsDTO intro = NewsDAO.Instance.GetNews(int.Parse(Id));
            if (intro == null)
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View(intro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Check.Out();

            if(NewsDAO.Instance.DeleteNews(Id)) return RedirectToAction("Index","NewsAdmin");

            return View();
        }

        public ActionResult Details(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            NewsDTO intro = NewsDAO.Instance.GetNews(int.Parse(Id));
            if (intro == null)
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View(intro);
        }

    }
}