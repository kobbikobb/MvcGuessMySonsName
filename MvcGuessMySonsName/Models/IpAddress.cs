using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    public static class IpAddress
    {
        public static string Current
        {
            get
            {
                var address = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(address))
                    return address.Split(new char[] { ',' })[0];
                    
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
    }
}