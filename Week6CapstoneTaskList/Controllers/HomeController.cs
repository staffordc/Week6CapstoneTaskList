﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week6CapstoneTaskList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What's this about?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Microsoft fake contact page.";

            return View();
        }
    }
}