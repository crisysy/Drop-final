using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.ValueObjects
{
    public enum StilViata 
    {
        Sedentar = 1,
        [Display(Name = "Puțin activ")]
        PutinActiv =2,
        [Display(Name = "Moderat")]
        Moderat = 3,
        [Display(Name = "Activ")]
        Activ = 4,
        [Display(Name = "Foarte Activ")]
        FoarteActiv = 5

    }
}