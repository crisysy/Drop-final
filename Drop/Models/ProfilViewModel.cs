using Drop.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drop.Models
{
    public class ProfilViewModel
    {
        public Guid Id { get; set; }
        public string IdUtilizator { get; set; }
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