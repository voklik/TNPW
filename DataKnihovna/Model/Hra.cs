using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using DataKnihovna.Interface;
using NHibernate.Type;

namespace DataKnihovna.Model
{
   public class Hra :IEntity

    {
        public virtual int Id { get; set; }
        [Required (ErrorMessage = "Název hry je vyžadován)")]
        public virtual String Nazev { get; set; }

        [Required(ErrorMessage = "Popis hry je vyžadován)")]
        public virtual String Popis { get; set; }

        [Required(ErrorMessage = "Nastavení slevy  je vyžadováno)")]
        [Range(0.0,1.0, ErrorMessage ="Sleva může být nastavena od 0.0 až 1.0")]
        public virtual double Sleva { get; set; }

        [Required(ErrorMessage = "Nastavení Ceny  je vyžadováno)")]
        [Range(0, 100000, ErrorMessage = "Cena může být nastavena od 0 až 100 000 - Jenom celá čísla")]
        public virtual int Cena { get; set; }

//  [Required(ErrorMessage = "Nastavení Platformy  je vyžadováno)")]
        public virtual Platforma Platforma { get; set; }

      //  [Required(ErrorMessage = "Nastavení Vydavatele  je vyžadováno)")]
        public virtual Vydavatel Vydavatel { get; set; }



        public virtual string Ikona { get; set; }


        public virtual string TypIkona { get; set; }


        [Required(ErrorMessage = "Nastavení počtu kopii skladem  je vyžadováno)")]
        [Range(0,100000 , ErrorMessage = "Počet kopii skladem může být nastavena od 0 až 100 000 - Jenom celá čísla")]
        public virtual int Skladem { get; set; }

        [Required(ErrorMessage = "Nastavení ,jestli hra se má ukazovat běžnému uživateli, musí být nastaveno)")]

        public virtual Boolean Aktivovano { get; set; }


        [Required(ErrorMessage = "Nastavení data vydání je u hry vyžadováno - stačí text, že neoznámeno)")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public virtual String Vydano { get; set; }


        [Required(ErrorMessage = "Nastavení DPH u hry  je vyžadováno)")]
        [Range(0.0, 1.0, ErrorMessage = "DPH může nabývat hodnot mezi 0.0 až 1.0")]

        public virtual Double Dph { get; set; }



        public Hra( )
        {
         
        }


        public virtual Double usetreni()
        {
            return ( Cena - aktualniCena()); 
        }

        public virtual Double aktualniCena()
        {
            return Cena- Cena*Sleva;
        }
        public virtual Double aktualniCenasDPH()
        {
            return aktualniCena()*Dph+ aktualniCena();
        }

    }
}
