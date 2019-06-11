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
    [Table("Profiluri")]
    public class Profil
    {
        [Key]
        public Guid Id { get; set; }

        public string IdUtilizator { get; set; }

        [ForeignKey("IdUtilizator")]
        public virtual ApplicationUser User { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Oras { get; set; }

        public Sex? Sex { get; set; }

        public int? Greutate { get; set; }

        public int? Inaltime { get; set; }

        public GrupeSanguine? GrupaSanguina { get; set; }

        public Rh? Rh { get; set; }
    }
}