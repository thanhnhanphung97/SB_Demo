using Demo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.Models.DTO;
using Demo.Areas.Admin.Models;

namespace Demo.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [HttpGet]
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            Session["id"] = "";
            ViewBag.Text = Session["loginSession"];
            return View();
            
        }
        public JsonResult GetAllIntro()
        {
            var listintro = IntroducesDAO.Instance.GetListIntroducts();
            return Json(listintro, JsonRequestBehavior.AllowGet);
        }
        public string AddIntroduce(IntroducesModel intro)
        {
            if (InsertIntroduces(intro.Name, intro.Img, intro.Data, intro.Describe, intro.Color)) return "Success";
            else return "Fail";
        }
        bool InsertIntroduces(string name, string img, float data, string describe, string color)
        {
            return IntroducesDAO.Instance.InsertIntroduces(name, img, data, describe, color);
        }
        public JsonResult getIntroduceByNo(string Id)
        {
            var introList = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            return Json(introList, JsonRequestBehavior.AllowGet);
        }
        public string UpdateIntroduce(IntroducesModel Intro)
        {
            int no = Convert.ToInt32(Intro.Id);
            if(EditIntroduce(no, Intro.Name, Intro.Img, Intro.Data, Intro.Describe, Intro.Color)) return "Employee Updated";
            else return "Invalid Employee";
        }
        bool EditIntroduce(int id, string name, string img, float data, string describe, string color)
        {
            return IntroducesDAO.Instance.EditIntroduces(id, name, img, data, describe, color);
        }
        public string DeleteIntroduce(int id)
        {
            //int no = Convert.ToInt32(Intro.Id);
            if(DeleteIntro(id)) return "Introduce Deleted";
            else return "Invalid Employee";
        }
        bool DeleteIntro(int id)
        {
            return IntroducesDAO.Instance.DeleteIntroduces(id);
        }


        public JsonResult GetAllN()
        {
            var listN = NewsDAO.Instance.GetListNews();
            return Json(listN, JsonRequestBehavior.AllowGet);
        }
        public string AddNew(NewsModel N)
        {
            if (InsertNews(N.Name, N.Img, N.Describe)) return "Success";
            else return "Fail";
        }
        bool InsertNews(string name, string img, string describe)
        {
            return NewsDAO.Instance.InsertNews(name, img, describe,null);
        }
        public JsonResult getNewByNo(string Id)
        {
            var NList = NewsDAO.Instance.GetNews(int.Parse(Id));
            return Json(NList, JsonRequestBehavior.AllowGet);
        }
        public string UpdateNew(NewsModel N)
        {
            int no = Convert.ToInt32(N.Id);
            if (EditNew(no, N.Name, N.Img,N.Describe)) return "Employee Updated";
            else return "Invalid Employee";
        }
        bool EditNew(int id, string name, string img,  string describe)
        {
            return NewsDAO.Instance.EditNews(id, name, img, describe,null);
        }
        public string DeleteNew(int id)
        {
            //int no = Convert.ToInt32(Intro.Id);
            if (DeleteN(id)) return "Introduce Deleted";
            else return "Invalid Employee";
        }
        bool DeleteN(int id)
        {
            return NewsDAO.Instance.DeleteNews(id);
        }
    }
}