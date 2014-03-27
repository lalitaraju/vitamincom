using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitaminsCom.MVC.Models;

namespace VitaminsCom.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailModelBuilder _emailModelBuilder;

        public HomeController()
            : this(new EmailModelBuilder())
        {
        
        }
        public HomeController(IEmailModelBuilder emailOptInModelBuilder)
        {
            _emailModelBuilder = emailOptInModelBuilder;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Joint()
        {
            return View();
        }



        public ActionResult Heart()
        {
            return View();
        }
    [HttpPost]
        public ActionResult EmailOptIn(EmailModel model)
        {
            
            if (model.Email== null)
            {
                return PartialView();
            }

            if (!ModelState.IsValid)
                return PartialView();

            var viewModel = _emailModelBuilder.SaveEmail(model);
            return  PartialView(viewModel);
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
