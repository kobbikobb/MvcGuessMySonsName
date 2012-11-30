using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    public class GuessesRepository
    {
        private readonly DbGuesss dbGuesses;

        public GuessesRepository()
        {
            dbGuesses = new DbGuesss(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public List<Guess> GetGuesses()
        {
            return dbGuesses.Guesses.ToList();
        }

        public List<GuessedName> GetGuessedNames()
        {
            return dbGuesses.Guesses.GroupBy(x => x.Name)
                .Select(x => new GuessedName() { Name = x.Key, Count = x.Count() })
                .OrderByDescending(x=>x.Count)
                .ToList();
        }

        public void SaveGuess(string name)
        {
            var guess = new Guess();
            guess.Name = name;
            guess.Date = DateTime.Now;
            guess.Ip = HttpContext.Current.Request.UserHostAddress;

            dbGuesses.Guesses.Add(guess);
            dbGuesses.SaveChanges();
        }
    }
}