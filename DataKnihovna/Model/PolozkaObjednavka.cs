using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class PolozkaObjednavka : IEntity
    {
        public int Id { get; set; }
        public bool Aktivovano { get; set; }

        public virtual Hra Hra { get; set; }
        public virtual int ObjednavkaID { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován.")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Jen celá čísla")]
        public virtual int Mnozstvi { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]

        public virtual double TehdejsiCena { get; set; }
        public virtual Stav Stav { get; set; }
    }
}
