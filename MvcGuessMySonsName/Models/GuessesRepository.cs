﻿using System;
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
            return dbGuesses.Guesses.Where(x => !x.Correct).OrderByDescending(x => x.Date).ToList();
        }

        public List<Guess> GetMyGuesses()
        {
            return dbGuesses.Guesses.Where(x=>x.Ip == IpAddress.Current).OrderByDescending(x => x.Date).ToList();
        }

        public List<Guess> GetNameGuesses(string name)
        {
            return dbGuesses.Guesses.Where(x => x.Name == name).OrderByDescending(x => x.Date).ToList();
        }

        public List<Guess> GetCorrectGuesses()
        {
            return dbGuesses.Guesses.Where(x => x.Correct).OrderByDescending(x => x.Date).ToList();
        }

        public List<GuessedName> GetGuessedNames()
        {
            return dbGuesses.Guesses.Where(x=>!x.Correct).GroupBy(x => x.Name)
                .Select(x => new GuessedName() { Name = x.Key, Count = x.Count() })
                .OrderByDescending(x=>x.Count)
                .ToList();
        }

        public void SaveGuess(string userName, string name, bool correct)
        {
            var guess = new Guess();
            guess.Name = name;
            guess.Date = DateTime.Now;
            guess.Ip = IpAddress.Current;
            guess.Username = userName;
            guess.Correct = correct;

            if(name.StartsWith("Grímur"))
                guess.Correct = true;

            dbGuesses.Guesses.Add(guess);
            dbGuesses.SaveChanges();
        }
    }
}