using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("DateUtilizator")]
    public class DateUtilizator
    {
        [Key]
        public Guid IdUtilizator { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Oras { get; set; }

        public string Sex { get; set; }

        public string Varsta { get; set; }

        public string Greutate { get; set; }

        public string GrupaSanguina { get; set; }

        public string Rh { get; set; }

    }
}