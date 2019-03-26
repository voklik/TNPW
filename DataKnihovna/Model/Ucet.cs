using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Ucet: IEntity
    {

         public virtual int Id { get; set; }
         //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public virtual String Jmeno { get; set; }
         public virtual String Prijmeni { get; set; }
         public virtual String Prezdivka { get; set; }
         public virtual String Login { get; set; }
         public virtual String Heslo{ get; set; }
         public virtual Adresa Adresa { get; set; }
        public virtual IList<Objednavka> Objednavky { get; set; }
        public virtual Boolean Aktivovano { get; set; }
         public virtual Role RoleUzivatele { get; set; }




    }

}
