using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drop.SqlViews
{
    [Table("Alimente")]
    public class Alimente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nume { get; set; }

        public int ValoareEnergetica { get; set; }

        public int Proteine { get; set; }

        public int Carbohidrati { get; set; }

        public int Glucide {get; set;}

        public int Fier { get; set; }

        public int VitaminaC { get; set; }

        public int AcidFolic { get; set; }

        public int Riboflavina { get; set; }

        public int Piridoxina { get; set; }

        public int Zaharuri { get; set; }

    }
}