using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKnihovna.DAO;
using DataKnihovna.Interface;

namespace DataKnihovna.Model
{
    public class Objednavka : IEntity
    {
   
        public virtual int Id { get; set; }

        public virtual string Cislo { get; set; }
        public virtual String Jmeno { get; set; }
        public virtual String Prijmeni { get; set; }

        public virtual String Telefon { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public virtual String Email { get; set; }
        public bool Aktivovano { get; set; }
        public virtual int IdUser { get; set; }
        public virtual Stav Stav { get; set; }
        public virtual IList<PolozkaObjednavka> Polozky { get; set; }
        public virtual DateTime DatumObjednavky { get; set; }
        public virtual PlatetbniMoznost Platba { get; set; }
        public virtual DopravaMoznost Doprava { get; set; }
        public virtual Adresa Adresa { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]

        public virtual Double CenaDopravy { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]

        public virtual Double CenaPlatby { get; set; }
        [Required(ErrorMessage = "Tento prvek je vyžadován. Zapisuje se desetiný tvar jako X,X)")]
        [Range(0, 100000, ErrorMessage = "Tento prvek musí být kladný > nastavena od 0 až 100 000 - Zapisuje se desetiný tvar jako X,X)")]

        public virtual Double CenaCelkem { get; set; }
        public void prepocet()
        {
            CenaCelkem = 0.0;
            foreach (PolozkaObjednavka polozka in Polozky)
            {
                if(polozka.Stav.Id==8)
                CenaCelkem =CenaCelkem+ (polozka.TehdejsiCena*polozka.Mnozstvi);
            }


            KombinaceMoznostiDao kombinaceMoznostiDao = new KombinaceMoznostiDao();
            KombinaceMoznosti kombinace = kombinaceMoznostiDao.IsKombinace(Doprava.Id, Platba.Id,false);
            if (kombinace !=null)
            {
                if(CenaCelkem>=kombinace.CenaObjednavky)
                CenaDopravy = kombinace.CenaDoprava;
                CenaPlatby = kombinace.CenaPlatebni;
                CenaCelkem += CenaDopravy;
                CenaCelkem += CenaPlatby;
            }
            else
            {
                CenaCelkem += CenaDopravy;
                CenaCelkem += CenaPlatby;
            }
          
        }
    }
}
