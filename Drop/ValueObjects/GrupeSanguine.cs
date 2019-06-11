using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Drop.ValueObjects
{
    public enum GrupeSanguine
    {
        [Display(Name = "0")]
        Zero = 1,
        A = 2,
        B=3,
        AB=4
    }
}