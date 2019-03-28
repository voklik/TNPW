using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Adresa : IEntity
    {
    public int Id { get; set; }
    public bool Aktivovano { get; set; }
    
    public virtual String Mesto { get; set; }
    public virtual String Zeme { get; set; }

        public virtual String UliceCP { get; set; }
    public virtual string PSC { get; set; }

    }

}
