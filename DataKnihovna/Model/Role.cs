using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
   public class Role:IEntity
    {
        public virtual int Id { get; set; }
        public virtual String Identifikator { get; set; }
        public virtual Boolean Aktivovano { get; set; }
        public virtual String Popis { get; set; }

    }
}
