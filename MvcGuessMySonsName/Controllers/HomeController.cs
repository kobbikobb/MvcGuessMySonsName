using MvcGuessMySonsName.Models;
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
        public ActionResult Index(string guessedName)
        {
            ViewBag.GuessedName = guessedName;

            var theName = new TheName();
            ViewBag.GuessResult = theName.IsName(guessedName);

            return View();
        }
    }
}
