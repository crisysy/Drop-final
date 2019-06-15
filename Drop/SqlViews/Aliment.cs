using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("Alimente")]
    public class Aliment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nume { get; set; }

        public decimal ValoareEnergetica { get; set; }

        public decimal Proteine { get; set; }

        public decimal Carbohidrati { get; set; }

        public decimal Glucide {get; set;}

        public decimal Fier { get; set; }

        public decimal VitaminaC { get; set; }

        public decimal AcidFolic { get; set; }

        public decimal Riboflavina { get; set; }

        public decimal Piridoxina { get; set; }

        public decimal Zaharuri { get; set; }

    }
}