using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    //Jakob Jónasson
    public class TheName
    {
        private string hashedFirstName = "AJMtM0JjY3VthyhbE/sQtRnxeRBax16qL4XpSfmwa18M9d1ZrsxOOJb9aAWbsALrjg==";
        private string hasedFullName = "AG9Yo9bFokfBA6y4A4JVovsh8ogQksUYdqirs/LxQtyPFwL3xV42lCG5wJApDqCcXA==";
        private readonly GuessesRepository guessesRepository;

        public TheName()
        {
            guessesRepository = new GuessesRepository();
        }

        public bool IsName(string name)
        {
            return IsName(HttpContext.Current.User.Identity.Name, name);
        }

        public bool IsName(string userName, string name)
        {
            var isName = System.Web.Helpers.Crypto.VerifyHashedPassword(hasedFullName, name) ||
                System.Web.Helpers.Crypto.VerifyHashedPassword(hasedFullName, name);

            if (!string.IsNullOrEmpty(userName))
                guessesRepository.SaveGuess(userName, name);

            return System.Web.Helpers.Crypto.VerifyHashedPassword(hashedFirstName, name) || System.Web.Helpers.Crypto.VerifyHashedPassword(hasedFullName, name);
        }
    }
}