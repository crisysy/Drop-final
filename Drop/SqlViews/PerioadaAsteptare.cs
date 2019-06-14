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

        public TipDonatie TipDonatie { get; set; }

        public int Interval { get; set; }

    }
}