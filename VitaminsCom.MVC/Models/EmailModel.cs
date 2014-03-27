using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.Web.Mvc;


namespace VitaminsCom.MVC.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        // [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string AcqSource { get; set; }
        public string Acqsubsource { get; set; }
        public string DivisionName { get; set; }
        public string Language { get; set; }
      
    }
}