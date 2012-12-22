using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    public class Guess
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public bool Correct { get; set; }
        public string Ip { get; set; }
    }
}