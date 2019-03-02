using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Vydavatel : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Název vydavatele je vyžadován)")]

        public virtual String Nazev { get; set; }
        public Vydavatel()
        {

        }
        public Vydavatel(int id , string nazev)
        {
            this.Id = id;
            this.Nazev = nazev;
        }
    }
}
