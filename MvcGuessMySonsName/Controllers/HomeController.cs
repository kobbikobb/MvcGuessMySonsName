﻿using MvcGuessMySonsName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTheName.Controllers
{
    //Jakob Jónasson
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //        
        // POST: /Home/
        [HttpPost]
        public ActionResult Index(string userName, string guessedName)
        {
            if (Request.IsAuthenticated)
                userName = System.Web.HttpContext.Current.User.Identity.Name;

            if (IsErrorInPost(userName, guessedName))
                return View();

            ViewBag.YourName = userName;
            ViewBag.GuessedName = guessedName;
            
            var theName = new TheName();

            ViewBag.GuessResult = theName.IsName(userName, guessedName);

            return View();
        }

        private bool IsErrorInPost(string userName, string guessedName)
        {
            bool error = false;
            if (string.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("userName", "Vinsamlegast settu inn nafn þitt");
                error = true;
            }
            if (string.IsNullOrEmpty(guessedName))
            {
                ModelState.AddModelError("guessedName", "Vinsamlegast settu inn ágiskun");
                error = true;
            }

            return error;

        }
    }
}
