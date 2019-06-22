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

        [Display(Name = "Oraș")]
        public string Oras { get; set; }

        public Sex? Sex { get; set; }

        [Display(Name = "Greutate (kg)")]
        [Range(0, int.MaxValue, ErrorMessage = "Greutatea nu poate fi un număr negativ")]

        public int? Greutate { get; set; }

        [Display(Name = "Înălțime (cm)")]
        [Range(0, int.MaxValue, ErrorMessage = "Înălțimea nu poate fi un număr negativ")]
        public int? Inaltime { get; set; }

        [Display(Name = "Grupa Sanguină")]
        public GrupeSanguine? GrupaSanguina { get; set; }

        public Rh? Rh { get; set; }

        [Display(Name = "Stilul de viață")]
        public StilViata StilDeViata { get; set; }
    }
}