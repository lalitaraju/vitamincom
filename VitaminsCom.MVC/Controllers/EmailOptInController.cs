using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitaminsCom.MVC.Models;

namespace VitaminsCom.MVC.Controllers
{
    public class EmailOptInController : Controller
    {
         private readonly IEmailModelBuilder _emailModelBuilder;

        public EmailOptInController()
            : this(new EmailModelBuilder())
        {
        
        }
        public EmailOptInController(IEmailModelBuilder emailOptInModelBuilder)
        {
            _emailModelBuilder = emailOptInModelBuilder;
        }

        public ActionResult EmailOptIn(EmailModel model)
        {
           
            if (model.Email == null)
            {
                return PartialView();
            }

            if (!ModelState.IsValid)
                return PartialView();

            var viewModel = _emailModelBuilder.SaveEmail(model.Email);
            return PartialView();
        }
    }
}
