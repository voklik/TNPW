﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class PolozkaKosik : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Boolean Aktivovano { get; set; }

        public virtual int IdUser { get; set; }
        public virtual Hra Hra { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován.")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Jen celá čísla")]
        public virtual int Mnozstvi { get; set; }
    }
}
