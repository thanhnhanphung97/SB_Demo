using Demo.Models.DAO;
using Demo.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Areas.Admin.Models;
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
            //Session["loginSession"] = "admin";
            Check.Out();
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View();
        }

        [HttpPost,ValidateInput(false),ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name, string Img, float Data, string Describe, string Color) //IntroducesModel introModel
        {
            //Session["loginSession"] = "admin";
            //string Img = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            //string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            //Img = Img + DateTime.Now.ToString("yymmssfff") + extension;

            //string Img = introModel.ImageFile.FileName;
            //Img = Path.Combine(Server.MapPath("~/Images/"), Img);
            //if (System.IO.File.Exists(Img))
            //{
            //    ViewBag.Text = "Image name is identical.";
            //    return View();
            //}
            //else ViewBag.Text = "";
            //introModel.ImageFile.SaveAs(Img);
            //Img = introModel.ImageFile.FileName;

            if (InsertIntroduces(Name, Img, Data, Describe, Color))
            {
                return RedirectToAction("Index", "IntroducesAdmin");
            }
            else
                return View();
        }

        bool InsertIntroduces(string name,string img,float data,string describe,string color)
        {
            return IntroducesDAO.Instance.InsertIntroduces(name, img, data, describe, color);
        }
        
        public ActionResult Edit(string Id)
        {
            Session["loginSession"] = "admin";
            if (Id==null||!Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            if (intro == null)
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View(intro);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int Id,string Name, string Img, float Data, string Describe, string Color)
        //{
        //    if(EditIntroduces(Id, Name, Img, Data, Describe, Color))
        //    {
        //        return RedirectToAction("Index", "IntroducesAdmin");
        //    }
        //    return View();
        //}
        public ActionResult Edit(int Id,string Name, string Img, float Data, string Describe, string Color)
        {
            Session["loginSession"] = "admin";
            if (EditIntroduces(Id, Name, Img, Data, Describe, Color))
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
            if (Id == null || !Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
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

            if(DeleteIntroduces(Id)) return RedirectToAction("Index","IntroducesAdmin");

            return View();
        }

        bool DeleteIntroduces(int id)
        {
            //IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(id);
            //string img = intro.Img;
            //string fullPath = Server.MapPath("~/Images/" + img);
            //if (System.IO.File.Exists(fullPath))
            //{
            //    System.IO.File.Delete(fullPath);
            //}
            return IntroducesDAO.Instance.DeleteIntroduces(id);
        }

        public ActionResult Details(string Id)
        {
            if (Id == null || !Check.isNumber(Id))
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Check.Out();
            IntroducesDTO intro = IntroducesDAO.Instance.GetIntroducts(int.Parse(Id));
            if (intro == null)
            {
                Response.Redirect(Session["currentPage"].ToString());
            }
            Session["currentPage"] = Request.Url.AbsoluteUri;
            return View(intro);
        }
        
    }
}