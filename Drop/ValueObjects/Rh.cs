using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.ValueObjects
{
    public enum Rh
    {
        [Display(Name = "Rh Pozitiv")]
        RhP = 1,
        [Display(Name = "Rh Negativ")]
        RhN= 2
    }
}