using MvcGuessMySonsName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGuessMySonsName.Controllers
{
    [Authorize]
    public class GuessesController : Controller
    {
        //
        // GET: /Guesses/

        public ActionResult Index()
        {
            var repository = new GuessesRepository();

            var theName = new TheName();

            var guesses = repository.GetGuesses().
                Where(x => !theName.VerifyName(x.Name)).ToList();
            
            return View(guesses);
        }

        //
        // GET: /Guesses/MyGuesses

        public ActionResult MyGuesses()
        {
            var repository = new GuessesRepository();

            return View("Index", repository.GetMyGuesses());
        }

        //
        // GET: /Guesses/GetNameGuesses
        public ActionResult GetNameGuesses(string name)
        {
            var repository = new GuessesRepository();

            return PartialView("NameGuesses", repository.GetNameGuesses(name));
        }

    }
}
