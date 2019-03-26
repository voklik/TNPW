using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class PlatetbniMoznost : IEntity
    {
        public virtual int Id { get; set; }
        public bool Aktivovano { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován)")]
        public virtual String Nazev { get; set; }
        [Required(ErrorMessage = "Popis hry je vyžadován)")]
        public virtual String Popis { get; set; }
        [Required(ErrorMessage = "Popis hry je vyžadován)")]
        public virtual Double Cena { get; set; }
    }
}
