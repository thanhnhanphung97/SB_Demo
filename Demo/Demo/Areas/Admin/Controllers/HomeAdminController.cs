﻿using Demo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using Demo.Models.DTO;
namespace Demo.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [HttpGet]
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            Check.Out();
            ViewBag.Text = Session["loginSession"];
            return View();
            
        }
    }
}