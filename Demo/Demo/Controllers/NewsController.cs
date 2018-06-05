using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models.DAO;
using Demo.Models.DTO;

namespace WebApplication1.Controllers
{
    public class newsController : Controller
    {
        List<NewsDTO> news = NewsDAO.Instance.GetListNews();
        // GET: news
        public ActionResult Index()
        {
            return View(news.ToList());
        }

        public ActionResult Details(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            NewsDTO news = NewsDAO.Instance.GetNews(int.Parse(Id));
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
    }
}