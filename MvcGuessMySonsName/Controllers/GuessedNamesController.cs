using MvcGuessMySonsName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGuessMySonsName.Controllers
{
    [Authorize]
    public class GuessedNamesController : Controller
    {
        //
        // GET: /GuessedNames/

        public ActionResult Index()
        {
            var repository = new GuessesRepository();
            var theName = new TheName();

            var guessedNames = repository.GetGuessedNames().
                Where(x => !theName.VerifyName(x.Name)).ToList();

            return View(guessedNames);
        }
    }
}
