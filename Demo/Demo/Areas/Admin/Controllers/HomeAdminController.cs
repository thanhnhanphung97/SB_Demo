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


        //Partners controller
        public JsonResult GetAllPartners()
        {
            var listpartner = PartnersDAO.Instance.GetListPartners();
            return Json(listpartner, JsonRequestBehavior.AllowGet);
        }
        public string AddPartner(PartnersModel partner)
        {
            if (InsertPartner(partner.Name, partner.Img, partner.Describe, partner.Background)) return "Success";
            else return "Fail";
        }
        bool InsertPartner(string name, string img, string describe, string background)
        {
            return PartnersDAO.Instance.InsertPartners(name, img, describe, background);
        }
        public JsonResult getPartnerById(string Id)
        {
            var partner = PartnersDAO.Instance.GetPartners(int.Parse(Id));
            return Json(partner, JsonRequestBehavior.AllowGet);
        }
        public string UpdatePartner(PartnersModel partner)
        {
            int no = Convert.ToInt32(partner.Id);
            if (EditPartner(no, partner.Name, partner.Img, partner.Describe, partner.Background)) return "Partners Updated";
            else return "Invalid Partners";
        }
        bool EditPartner(int id, string name, string img, string describe, string background)
        {
            return PartnersDAO.Instance.EditPartners(id, name, img, describe, background);
        }
        public string DeletePartner(int id)
        {
            //int no = Convert.ToInt32(Intro.Id);
            if (DeletePart(id)) return "Partner Deleted";
            else return "Invalid Partner";
        }
        bool DeletePart(int id)
        {
            return PartnersDAO.Instance.DeletePartners(id);
        }


    }
}