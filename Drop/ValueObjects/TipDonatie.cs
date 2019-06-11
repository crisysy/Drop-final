using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.ValueObjects
{
    public enum TipDonatie
    {
        [Display(Name = "Donare de sânge total")]
        Total = 1,
        [Display(Name = "Donare de trombicite")]
        Trombocite = 2,
        [Display(Name = "Donare de plasmă")]
        Plasma = 3
    }
}