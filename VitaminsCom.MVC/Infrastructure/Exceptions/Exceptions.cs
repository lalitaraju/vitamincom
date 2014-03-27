using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VitaminsCom.MVC.Infrastructure.Exceptions
{
    public class RecordNotdFoundException: Exception
    {
    }
    public class RedirectToUrlException : Exception
    {
        public string Url { get; set; }

        public RedirectToUrlException(string url)
            : base()
        {
            Url = url;
        }
    }

}