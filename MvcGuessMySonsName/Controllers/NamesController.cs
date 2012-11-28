using MvcGuessMySonsName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcGuessMySonsName.Controllers
{
    //Jakob Jónasson
    public class NamesController : ApiController
    {
        // GET api/names/getisname?name=
        public bool GetIsName(string name)
        {
            var theName = new TheName();

            return theName.IsName(name);
        }
    }
}