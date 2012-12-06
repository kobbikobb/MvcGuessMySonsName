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
            return dbGuesses.Guesses.OrderByDescending(x=>x.Date).ToList();
        }

        public List<Guess> GetMyGuesses()
        {
            return dbGuesses.Guesses.Where(x=>x.Ip == IpAddress.Current).OrderByDescending(x => x.Date).ToList();
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
            guess.Ip = IpAddress.Current;
            guess.Username = HttpContext.Current.User.Identity.Name;

            dbGuesses.Guesses.Add(guess);
            dbGuesses.SaveChanges();
        }
    }
}