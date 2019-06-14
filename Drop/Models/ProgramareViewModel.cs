using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.Models
{
    public class ProgramareViewModel
    {

            [Display(Name = "Ați consumat alcool în ultimele 24 de ore?")]
            [Range(typeof(bool), "true", "true", ErrorMessage = "Vă rugăm să așteptați 24 de ore")]
            public bool alcool { get; set; }

    }
}