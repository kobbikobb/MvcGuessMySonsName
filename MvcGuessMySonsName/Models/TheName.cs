using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    //Jakob Jónasson
    public class TheName
    {
        private string name = "AG9Yo9bFokfBA6y4A4JVovsh8ogQksUYdqirs/LxQtyPFwL3xV42lCG5wJApDqCcXA==";

        public TheName()
        {

        }

        public bool IsName(string theName)
        {
            return System.Web.Helpers.Crypto.VerifyHashedPassword(name, theName);
        }
    }
}