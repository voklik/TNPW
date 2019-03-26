using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
   public class Stav:IEntity
    {
        public virtual int Id { get; set; }
        public bool Aktivovano { get; set; }
        public virtual String Nazev { get; set; }
    }
}
