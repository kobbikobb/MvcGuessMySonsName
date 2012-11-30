﻿using MvcGuessMySonsName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGuessMySonsName.Controllers
{
    public class GuessesController : Controller
    {
        //
        // GET: /Guesses/

        public ActionResult Index()
        {
            var repository = new GuessesRepository();

            return View(repository.GetGuesses());
        }

    }
}
