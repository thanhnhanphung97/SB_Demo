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
    public class PartnersAdminController : Controller
    {
        // GET: Admin/Introduces
        public ActionResult Index()
        { 
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            List<PartnersDTO> list = PartnersDAO.Instance.GetListPartners();
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
        public ActionResult Create(string Name,string Img,string Describe,string Background)
        {
            if (PartnersDAO.Instance.InsertPartners(Name, Img, Describe, Background))
            {
                return RedirectToAction("Index", "PartnersAdmin");
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
            Session["currentPage"] = Request.Url.AbsoluteUri;
            PartnersDTO intro = PartnersDAO.Instance.GetPartners(int.Parse(Id));
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string Name, string Img, string Describe, string Background)
        {
            if(PartnersDAO.Instance.EditPartners(Id, Name, Img, Describe, Background))
            {
                return RedirectToAction("Index", "PartnersAdmin");
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
            Session["currentPage"] = Request.Url.AbsoluteUri;
            PartnersDTO intro = PartnersDAO.Instance.GetPartners(int.Parse(Id));
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

            if(PartnersDAO.Instance.DeletePartners(Id)) return RedirectToAction("Index","PartnersAdmin");

            return View();
        }

        public ActionResult Details(string Id)
        {
            if (!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            PartnersDTO intro = PartnersDAO.Instance.GetPartners(int.Parse(Id));
            if (intro == null)
            {
                return HttpNotFound();
            }
            return View(intro);
        }

    }
}