﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRAutos_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            /*comment test*/

            /*Prueba 01 Eduardo1234*/

            /*<3*/

            /*comment test 23*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}