using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    //Jakob Jónasson
    public class TheName
    {
        private string hashedName = "AG9Yo9bFokfBA6y4A4JVovsh8ogQksUYdqirs/LxQtyPFwL3xV42lCG5wJApDqCcXA==";
        private readonly GuessesRepository guessesRepository;

        public TheName()
        {
            guessesRepository = new GuessesRepository();
        }

        public bool IsName(string name)
        {
            guessesRepository.SaveGuess(name);

            return System.Web.Helpers.Crypto.VerifyHashedPassword(hashedName, name);
        }
    }
}