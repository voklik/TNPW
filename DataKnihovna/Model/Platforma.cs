using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Platforma : IEntity
    {
        public virtual int Id { get; set; }
      
        public virtual String Nazev { get; set; }
        public Platforma()
        {

        }
    }
}
