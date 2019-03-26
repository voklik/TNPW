using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class KombinaceMoznosti : IEntity
    {

        public virtual int Id { get; set; }
        public bool Aktivovano { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován)")]
        public virtual PlatetbniMoznost PlatbaMoznost { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován)")]
        public virtual DopravaMoznost DopravaMoznost { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]

        public virtual double CenaDoprava { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]
        public virtual double CenaPlatebni { get; set; }
          [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
          [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]
        public virtual double CenaObjednavky { get; set; }
    }
}
