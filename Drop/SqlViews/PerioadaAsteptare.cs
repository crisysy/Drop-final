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
    [Table("PerioadeAsteptare")]
    public class PerioadaAsteptare
    {
        [Key]
        public Guid Id { get; set; }

        public string IdUtilizator { get; set; }

        [ForeignKey("IdUtilizator")]
        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Tip Donație")]
        public TipDonatie TipDonatie { get; set; }

        [Display(Name = "Interval (săptămâni)")]
        [Range(2, 90000000, ErrorMessage = "Sângele nu se poate regenera în mai puțin de două săptămâni. Vă rugăm să discutați cu medicul.")]
        public int Interval { get; set; }

    }
}