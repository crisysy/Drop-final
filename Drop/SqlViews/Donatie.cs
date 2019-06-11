using Drop.Models;
using Drop.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("Donatii")]
    public class Donatie
    {
        [Key]
        public Guid Id {get; set;}

        public string IdUtilizator { get; set; }

        [ForeignKey("IdUtilizator")]
        public virtual ApplicationUser User { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public string Centru { get; set; }

        [Display(Name = "Oraș")]
        public string Oras { get; set; }

        [Display(Name = "Tip donație")]
        public TipDonatie TipDonatie { get; set; }
    }
}