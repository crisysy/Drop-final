using Drop.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("Cereri")]
    public class Cerere
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Oraș")]
        public string Centru { get; set; }

        [Display(Name ="Data limită")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataLimita { get; set; }

        [Display(Name ="Donații necesare")]
        [Range(0, int.MaxValue, ErrorMessage = "Cererea nu poate fi un număr negativ.")]
        public int DonatiiNecesare { get; set; }

        [Display(Name ="Persoane care au contribuit")]
        public int Contributii { get; set; }

        [Display(Name ="Grupa sanguină necesară")]
        public GrupeSanguine?  GrupaSanguinaNecesara {get; set;}

    }
}