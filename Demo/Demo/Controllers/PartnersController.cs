using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models.DAO;
using Demo.Models.DTO;

namespace WebApplication1.Controllers
{
    public class PartnersController : Controller
    {
        List<PartnersDTO> partners = PartnersDAO.Instance.GetListPartners();
        // GET: news
        public ActionResult Index()
        {
            return View(partners.ToList());
        }
    }
}