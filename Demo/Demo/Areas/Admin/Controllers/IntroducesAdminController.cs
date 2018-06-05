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
    public class IntroducesAdminController : Controller
    {
        // GET: Admin/Introduces
        public ActionResult Index()
        { 
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            List<IntroducesDTO> list = IntroducesDAO.Instance.GetListIntroducts();
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
        public ActionResult Create(string Name,string Img,float Data,string Describe,string Color)
        {
            if (InsertIntroduces(Name, Img, Data, Describe, Color))
            {
                return RedirectToAction("Index", "IntroducesAdmin");
            }
            else return View();
        }

        bool InsertIntroduces(string name,string img,float data,string describe,string color)
        {
            return IntroducesDAO.Instance.InsertIntroduces(name, img, data, describe, color);
        }
        
        public ActionResult Edit(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id,string Name, string Img, float Data, string Describe, string Color)
        {
            if(EditIntroduces(Id, Name, Img, Data, Describe, Color))
            {
                return RedirectToAction("Index", "IntroducesAdmin");
            }
            return View();
        }

        bool EditIntroduces(int id, string name, string img, float data, string describe, string color)
        {
            return IntroducesDAO.Instance.EditIntroduces(id, name, img, data, describe, color);
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Check.Out();

            if(DeleteIntroduces(Id)) return RedirectToAction("Index","IntroducesAdmin");

            return View();
        }

        bool DeleteIntroduces(int id)
        {
            return IntroducesDAO.Instance.DeleteIntroduces(id);
        }

        public ActionResult Details(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }

    }
}