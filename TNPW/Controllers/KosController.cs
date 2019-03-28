using DataKnihovna.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;

namespace TNPW.Controllers
{
    public class KosController : Controller
    {
        // GET: Kos

        public ActionResult smazat(int id, int mnozstvi)
        {
            if (User.Identity.Name != "")
            {
                PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();
                PolozkaKosik polozka = polozkaKosikDao.GetById(id);



                polozkaKosikDao.Delete(polozka);
            }
            else
            {
                if (Request.Cookies["kosik"] != null)
                {
                    if (Request.Cookies["kosik"] == null)
                    {
                       
                    }
                    else
                    {
                        Response.Cookies["kosik"].Value = Request.Cookies["kosik"].Value.Replace( id + "," + mnozstvi,"") ;


                        Response.Cookies["kosik"].Expires = DateTime.Now.AddDays(7);
                    }
                       
                }
                return RedirectToAction("Kosik");
            }

            return RedirectToAction("Kosik");
        }
        public ActionResult editovat(int id, int mnozstvi, int Xmnozstvi)
        {
            if (User.Identity.Name != "")
            {
                PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();
                PolozkaKosik polozka = polozkaKosikDao.GetById(id);

                polozka.Mnozstvi = Xmnozstvi;


                polozkaKosikDao.Update(polozka);
            }
            
            else
            {
                if (Request.Cookies["kosik"] != null)
                {
                    String x = TNPW.utility.Utilityzer.getCookieValue("kosik");
                    if (x.Contains(id + "," + mnozstvi)==false)
                    {
                        Response.Cookies["kosik"].Value = Request.Cookies["kosik"].Value + "|" + id + "," + Xmnozstvi;

                    }
                    else
                    {
                       
                        Response.Cookies["kosik"].Value = Request.Cookies["kosik"].Value.Replace( + id + "," + mnozstvi,  id + "," +Xmnozstvi);

                    }

                }

                Response.Cookies["kosik"].Expires = DateTime.Now.AddDays(7);
            }

            
           
          
            return RedirectToAction("Kosik");
        }
        public ActionResult Pridat(int id,int mnozstvi)
        {
           

            if (User.Identity.Name!="")
            { 
            Ucet ucet = new UcetDao().GetByLogin(User.Identity.Name);
            PolozkaKosik polozka = new PolozkaKosik();
            polozka.Hra = new GameDao().GetById(id);
            polozka.Aktivovano = true;
            polozka.IdUser = ucet.Id;
            polozka.Mnozstvi = mnozstvi;

            PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();
            polozkaKosikDao.Create(polozka);
            }
            else
            {
            
                if (Request.Cookies["kosik"] == null)
                    Response.Cookies["kosik"].Value = id+","+mnozstvi;
                else
                {
                    String x = TNPW.utility.Utilityzer.getCookieValue("kosik");
                    if (x.Contains(id + "," + mnozstvi) == false)
                    {
                        Response.Cookies["kosik"].Value = Request.Cookies["kosik"].Value + "|" + id + "," + mnozstvi;

                    }
                    else
                    {
                        string objCartListString = Request.Cookies["kosik"].Value.ToString();
                        string[] objCartListStringSplit = objCartListString.Split('|');
                        int stare=-1;
                        foreach (string s in objCartListStringSplit)
                        {
                            
                            string[] ss = s.Split(',');
                          if (Convert.ToInt32(ss[0]) == id) ;
                            stare = Convert.ToInt32(ss[1]);
                        }

                        int nove = stare + mnozstvi;
                        Response.Cookies["kosik"].Value = Request.Cookies["kosik"].Value.Replace(+id + "," + stare, id + "," + nove);

                    }

                }

                Response.Cookies["kosik"].Expires = DateTime.Now.AddDays(7);
            }
            return RedirectToAction("Kosik");
        }
        public ActionResult Kosik()
        {
            PlatetbniMoznostDao platetbniMoznostDao = new PlatetbniMoznostDao();
            IList<PlatetbniMoznost> platba = platetbniMoznostDao.getAktiv(false);
            DopravaMoznostDao dopravaMoznostDao = new DopravaMoznostDao();
            IList<DopravaMoznost> doprava = dopravaMoznostDao.getAktiv(false);

            Ucet ucet = new Ucet();
            foreach (DopravaMoznost item in doprava)
            {
                item.Nazev = item.Nazev + " " + item.Cena + " Kč";
            }
            foreach (PlatetbniMoznost item in platba)
            {
                item.Nazev = item.Nazev + " " + item.Cena + " Kč";
            }
            ViewBag.platby = platba;
            ViewBag.doprava = doprava;

            if (User.Identity.Name!="")
            {
                 ucet = new UcetDao().GetByLogin(User.Identity.Name);
                IList<PolozkaKosik> polozky = new PolozkaKosikDao().GetByUzivatel(ucet.Id);
                Kosik kosik = new Kosik(polozky);
                @ViewBag.Jmeno = ucet.Jmeno;
                @ViewBag.Prijmeni = ucet.Prijmeni;
                @ViewBag.Telefon = ucet.Telefon;
                @ViewBag.Email = ucet.Email;
                @ViewBag.uzivatel = ucet.Id;

                @ViewBag.Mesto = ucet.Adresa.Mesto;
                @ViewBag.PSC = ucet.Adresa.PSC;
                @ViewBag.UliceCP = ucet.Adresa.UliceCP;
                @ViewBag.Zeme = ucet.Adresa.Zeme;

                return View(kosik);
            }
            else
            {
                if (Request.Cookies["kosik"] != null)
                {
                    string objCartListString = Request.Cookies["kosik"].Value.ToString();
                    string[] objCartListStringSplit = objCartListString.Split('|');
                    IList<PolozkaKosik> polozky = new List<PolozkaKosik>();
                   
                  
                    foreach (string s in objCartListStringSplit)
                    {
                        PolozkaKosik polozka = new PolozkaKosik();
                        string[] ss = s.Split(',');
                        polozka.Hra =new GameDao().GetById(Convert.ToInt32(ss[0])) ;
                        polozka.Mnozstvi = Convert.ToInt32(ss[1]);
                   
                               polozky.Add(polozka);      
                    }
                    Kosik kosik = new Kosik(polozky);
                    @ViewBag.Jmeno = ucet.Jmeno;
                    @ViewBag.Prijmeni = ucet.Prijmeni;
                    @ViewBag.Telefon = ucet.Telefon;
                    @ViewBag.Email = ucet.Email;
                    @ViewBag.uzivatel = ucet.Id;

                    @ViewBag.Mesto = ucet.Adresa.Mesto;
                    @ViewBag.PSC = ucet.Adresa.PSC;
                    @ViewBag.UliceCP = ucet.Adresa.UliceCP;
                    @ViewBag.Zeme = ucet.Adresa.Zeme;

                    return View(kosik);
                }
                else
                {
                    Kosik kosik = new Kosik();
                    @ViewBag.Jmeno = ucet.Jmeno;
                    @ViewBag.Prijmeni = ucet.Prijmeni;
                    @ViewBag.Telefon = ucet.Telefon;
                    @ViewBag.Email = ucet.Email;
                    @ViewBag.uzivatel = ucet.Id;

                    @ViewBag.Mesto = ucet.Adresa.Mesto;
                    @ViewBag.PSC = ucet.Adresa.PSC;
                    @ViewBag.UliceCP = ucet.Adresa.UliceCP;
                    @ViewBag.Zeme = ucet.Adresa.Zeme;

                    return View(kosik);
                }
              
            }
           
            
         
        }
        public ActionResult vyprazdnit ()
        {
            if (User.Identity.Name != "")
            {
                PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();
                



                polozkaKosikDao.vyprazdnit(new UcetDao().GetByLogin(User.Identity.Name).Id);
            }
            else
            {
              
               if (Request.Cookies["kosik"] == null)
                {
                }

                else
                {
                    var myCookie = new HttpCookie("kosik");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }

              
            }

         
            return RedirectToAction("Kosik");
        }
        public ActionResult vytvoritObjednavku(int? uzivatel,int platba,int doprava,string jmeno,string prijmeni,string email,string telefon,string mesto, string ulice,string psc, string zeme)
        {
            Objednavka o = new Objednavka();
            o.Adresa=new Adresa();
            o.Adresa.Aktivovano = true;
            o.Adresa.Mesto = mesto;
            o.Adresa.PSC = psc;
            o.Adresa.UliceCP = ulice;
            o.Adresa.Zeme = zeme;
            o.Aktivovano = true;
            o.DatumObjednavky=DateTime.Now;
            o.Doprava = new DopravaMoznostDao().GetById(doprava);
            o.Platba = new PlatetbniMoznostDao().GetById(platba);
            o.Jmeno = jmeno;
            o.Prijmeni = prijmeni;
            o.Telefon = telefon;
            o.Email = email;
            if (uzivatel!=null)
            {
                o.IdUser =(int) uzivatel;
            }
            Kosik kosik = new Kosik()  ;


            Ucet ucet =new Ucet();

            if (User.Identity.Name != "")
            {
                 ucet = new UcetDao().GetByLogin(User.Identity.Name);
                IList<PolozkaKosik> polozky = new PolozkaKosikDao().GetByUzivatel(ucet.Id);
                 kosik = new Kosik(polozky);

              
            }
            else
            {
                if (Request.Cookies["kosik"] != null)
                {
                    string objCartListString = Request.Cookies["kosik"].Value.ToString();
                    string[] objCartListStringSplit = objCartListString.Split('|');
                    IList<PolozkaKosik> polozky = new List<PolozkaKosik>();


                    foreach (string s in objCartListStringSplit)
                    {
                        PolozkaKosik polozka = new PolozkaKosik();
                        string[] ss = s.Split(',');
                        polozka.Hra = new GameDao().GetById(Convert.ToInt32(ss[0]));
                        polozka.Mnozstvi = Convert.ToInt32(ss[1]);

                        polozky.Add(polozka);
                    }
                     kosik = new Kosik(polozky);

                
                }
             

            }




          o.Polozky=new List<PolozkaObjednavka>();
          foreach (PolozkaKosik item in kosik.Polozky)
          {
              PolozkaObjednavka x= new PolozkaObjednavka();
              x.Hra = item.Hra;
              x.Aktivovano = true;
              x.Mnozstvi = item.Mnozstvi;
              x.Stav=new Stav();
              x.Stav.Id = 8;
              x.TehdejsiCena = item.Hra.aktualniCenasDPH();
              o.Polozky.Add(x);

          }




          o.prepocet();


            @ViewBag.Jmeno = ucet.Jmeno;
            @ViewBag.Prijmeni = ucet.Prijmeni;
            @ViewBag.Telefon = ucet.Telefon;
            @ViewBag.Email = ucet.Email;
            @ViewBag.uzivatel = ucet.Id;

            @ViewBag.Mesto = ucet.Adresa.Mesto;
            @ViewBag.PSC = ucet.Adresa.PSC;
            @ViewBag.UliceCP = ucet.Adresa.UliceCP;
            @ViewBag.Zeme = ucet.Adresa.Zeme;
            return View(o);
        }
    
        public ActionResult dokonceniObjednavky(Objednavka model)
        {
         PolozkaObjednavkaDao PolozkaObjednavkaDao = new PolozkaObjednavkaDao();
         ObjednavkaDao objednavkaDao=new ObjednavkaDao();
         AdresaDao adresaDao=new AdresaDao();


         Kosik kosik = new Kosik();




         if (User.Identity.Name != "")
         {
             Ucet ucet = new UcetDao().GetByLogin(User.Identity.Name);
             IList<PolozkaKosik> polozky = new PolozkaKosikDao().GetByUzivatel(ucet.Id);
             kosik = new Kosik(polozky);


         }
         else
         {
             if (Request.Cookies["kosik"] != null)
             {
                 string objCartListString = Request.Cookies["kosik"].Value.ToString();
                 string[] objCartListStringSplit = objCartListString.Split('|');
                 IList<PolozkaKosik> polozky = new List<PolozkaKosik>();


                 foreach (string s in objCartListStringSplit)
                 {
                     PolozkaKosik polozka = new PolozkaKosik();
                     string[] ss = s.Split(',');
                     polozka.Hra = new GameDao().GetById(Convert.ToInt32(ss[0]));
                     polozka.Mnozstvi = Convert.ToInt32(ss[1]);

                     polozky.Add(polozka);
                 }
                 kosik = new Kosik(polozky);


             }


         }




         model.Polozky = new List<PolozkaObjednavka>();
         foreach (PolozkaKosik item in kosik.Polozky)
         {
             PolozkaObjednavka x = new PolozkaObjednavka();
             x.Hra = item.Hra;
             x.Aktivovano = true;
             x.Mnozstvi = item.Mnozstvi;
             x.Stav = new Stav();
             x.Stav.Id = 8;
             x.TehdejsiCena = item.Hra.aktualniCenasDPH();
             model.Polozky.Add(x);

         }
         if (User.Identity.Name != "")
         {
             Ucet ucet = new UcetDao().GetByLogin(User.Identity.Name);
             model.IdUser = ucet.Id;


         }
            model.DatumObjednavky=DateTime.Now;
         model.Stav.Id = 1;
            adresaDao.Create(model.Adresa);
         objednavkaDao.Create(model);
         foreach (PolozkaObjednavka item in model.Polozky)
         {
             item.ObjednavkaID = model.Id;
             PolozkaObjednavkaDao.Create(item);
         }


         if (User.Identity.Name != "")
         {
             PolozkaKosikDao polozkaKosikDao = new PolozkaKosikDao();




             polozkaKosikDao.vyprazdnit(new UcetDao().GetByLogin(User.Identity.Name).Id);
         }
         else
         {

             if (Request.Cookies["kosik"] == null)
             {
             }

             else
             {
                 var myCookie = new HttpCookie("kosik");
                 myCookie.Expires = DateTime.Now.AddDays(-1d);
                 Response.Cookies.Add(myCookie);
             }


         }
            TempData["error"] = "Objednávka byla vytvořena č." +model.Cislo;
            return View("Zprava");
        }
        public ActionResult KombinaceMoznosti()
        {
            KombinaceMoznostiDao kombinaceMoznostiDao = new KombinaceMoznostiDao();
            IList<KombinaceMoznosti> kombinace = kombinaceMoznostiDao.getALLAktiv(false);
           
                return PartialView("KombinaceMoznostiAjax", kombinace);
          
        
        }
    }
    }