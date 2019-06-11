using Drop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("AportAlimentar")]
    public class AportAlimentar
    {
        [Key]
        public Guid Id { get; set; }

        public string IdUtilizator { get; set; }

        [ForeignKey("IdUtilizator")]
        public virtual ApplicationUser User { get; set; }

        public DateTime Data { get; set; }

        public Guid IdAliment { get; set; }

        [ForeignKey("IdAliment")]
        public virtual Aliment Aliment { get; set; }

        public int Cantitate { get; set; }

    }
}