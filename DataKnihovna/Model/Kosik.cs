using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Kosik
    {
        public  Kosik()
        { }

        public Kosik(IList<PolozkaKosik> polozky)
        {
            this.Polozky = polozky;
            prepocet();
        }

        public virtual  IList<PolozkaKosik> Polozky{ get; set; }
        public virtual Double Celkem { get; set; }

        public void prepocet()
        {
            Celkem = 0.0;
            foreach (PolozkaKosik polozkaKosik in Polozky)
            {
                Celkem += polozkaKosik.Hra.aktualniCenasDPH();
            }
        }

       
    }
}
