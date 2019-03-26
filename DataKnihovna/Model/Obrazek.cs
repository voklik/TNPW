using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
   public class Obrazek : IEntity
    {

        public virtual int Id { get; set; }
        public virtual Hra Game { get; set; }
        public virtual string  Ikona { get; set; }
        public virtual string Popis { get; set; }
        public virtual Boolean Aktivovano { get; set; }
    }
}
