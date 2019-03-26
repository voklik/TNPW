using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;
using TNPW.utility;

namespace TNPW.Areas.Administrativa.Controllers
{
   
    [Authorize(Roles = "pracovnik, admin")]
    public class HraController : Controller
    {
        // GET: Hra
        public ActionResult Hra(int? _page, int? _itemsOnPage, bool? vse)
        {


            int celkem;
            bool _vse = vse.HasValue ? vse.Value : false;
            int itemsOnPage = _itemsOnPage.HasValue ? _itemsOnPage.Value : Utilityzer.DefaultCountPerPage;
            int page = _page.HasValue ? _page.Value : 1;
             GameDao gameDao = new GameDao();
            IList<Hra> ucty = gameDao.getPaged(itemsOnPage, page, out celkem, _vse);
            ViewBag.pages = (int)Math.Ceiling((double)celkem / (double)itemsOnPage);
            ViewBag.soucasna = page;
            ViewBag.vse = vse;
            ViewBag.perPage = itemsOnPage;
            ViewBag.celkem = celkem;
          
            if (Request.IsAjaxRequest())
            {
                return PartialView("HraAjax", ucty);
            }

            return View(ucty);
        }

        public ActionResult pridatObrazek(int id_hry)
        {
          
            GameDao gameDao = new GameDao();
            Hra hra = gameDao.GetById(id_hry);
            Obrazek novy= new Obrazek();
            novy.Game = hra;
            novy.Aktivovano = true;
      
            return View(novy);
        }

        public ActionResult AddObrazek(Obrazek obrazek,string hra,HttpPostedFileBase obr)
        {
            GameDao gameDao = new GameDao();
            Hra hra1 = gameDao.GetById(int.Parse(hra));
            obrazek.Game = hra1;

            if (obr != null)
                {
                    if (obr.ContentType == "image/jpeg" || obr.ContentType == "image/png")

                    {
                        Image image = Image.FromStream(obr.InputStream);
                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image smallImage = ImageHelper.ScaleImage(image, 1080, 960);

                            Bitmap b = new Bitmap(smallImage);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";
                            b.Save(Server.MapPath("~/uploads/hry/" + imageName), ImageFormat.Jpeg);
                            smallImage.Dispose();
                            b.Dispose();
                            if (obrazek.Ikona != null)
                            {
                                try
                                {
                                    System.IO.File.SetAttributes(Server.MapPath("~/uploads/hry/" + obrazek.Ikona), FileAttributes.Normal);
                                    System.IO.File.Delete(Server.MapPath("~/uploads/hry/" + obrazek.Ikona));

                                }
                                catch (Exception e)
                                {

                                }

                            }

                            obrazek.Ikona = imageName;

                        }
                        else
                        {
                            obrazek.Ikona = Server.MapPath("~´/uploads/hry/" + obr.FileName);
                            obr.SaveAs(Server.MapPath("~´/uploads/hry/" + obr.FileName));
                        }
                        ObrazekDao obrazekDao = new ObrazekDao();
                        obrazekDao.Create(obrazek);
                        TempData["message-success"] = "Přidán obrázek";

                        return RedirectToAction("DetailHry", new{id=obrazek.Game.Id});
                }
                    else
                    {
                    TempData["err"] = "Chybí obrázek, nebo není typu JPG / PNG";
                    return View("pridatObrazek", obrazek);
                }
                }


            TempData["err"] = "Něco se pokazilo";
            return View("pridatObrazek", obrazek);



        }
        public ActionResult aktivace(String _id, int? _page, int? _itemsOnPage, bool? vse)
        {

            int id = int.Parse(_id);
            GameDao gameDao = new GameDao();
            Hra hra = gameDao.GetById(id);

            if (hra.Aktivovano)
                hra.Aktivovano = false;
            else
                hra.Aktivovano = true;


            gameDao.Update(hra);
            return RedirectToAction("Hra", new { _page = _page, vse = vse, _itemsOnPage = _itemsOnPage });
            // return RedirectToAction("DetailHry",hra.Id);
        }
        public ActionResult Search(string nazev)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.SearchName(nazev);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return View("Hra", ucty);
        }
    
        public ActionResult SearchVydavatel(int id)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.GetByVydavatel(id, out celkem, true);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return View("Hra", ucty);
        }
        public ActionResult SearchPlatforma(int id)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.GetByPlatforma(id, out celkem, true);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return View("Hra", ucty);
        }
        public JsonResult searchHrabyNazev(string query)
        {

            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            IList<Hra> hry = hryDao.SearchName(query);
            List<String> seznam = (from Hra u in hry select u.Nazev).ToList();
            return Json(seznam, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetailHry(int id)
        {
            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            DataKnihovna.Model.Hra hra = hryDao.GetById(id);
            ObrazekDao obrazekDao = new ObrazekDao();
            IList<Obrazek> obrazky = obrazekDao.GetByGame(hra.Id);
            ViewBag.obrazky = obrazky;

            return View(hra);
        }

        public ActionResult NovaHra()
        {
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
            ViewBag.platformy = platformy;
            ViewBag.vydavatele = vydavatele;
            return View();
        }
        [HttpPost] //aby nikdo nemohl to udělat přes url
        public ActionResult EditHra(int  _id)
        {
        
            GameDao gameDao = new GameDao();
            Hra hra = gameDao.GetById(_id);
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
      
            platformy.Insert(0,hra.Platforma);
            vydavatele.Insert(0,hra.Vydavatel);
            ViewBag.platformy = platformy;
            ViewBag.vydavatele = vydavatele;
          
            return View(hra);
        }

        [HttpPost]
        public ActionResult Update(Hra hra, string _platforma, string _vydavatel, HttpPostedFileBase obrazek)
        {

            // tato zatracená část musí existovat, jinak by  if (ModelState.IsValid) řval, protože viewbagy by byly prázdné
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
            ViewBag.platformy = platformy;
            ViewBag.vydavatele = vydavatele;




            GameDao gameDao = new GameDao();
         
            Vydavatel vyd;
            Platforma plat;
           
          

                if (ModelState.IsValid)
            {
              
                vyd = vydavateleDao.GetById(int.Parse(_vydavatel));
                plat = platformaDao.GetById(int.Parse(_platforma));
                hra.Vydavatel = vyd;
                hra.Platforma = plat;
                if (obrazek != null)
                {
                    if (obrazek.ContentType == "image/jpeg" || obrazek.ContentType == "image/png")
                    {
                        Image image = Image.FromStream(obrazek.InputStream);
                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image smallImage = ImageHelper.ScaleImage(image, 200, 200);

                            Bitmap b = new Bitmap(smallImage);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";
                            b.Save(Server.MapPath("~/uploads/hry/" + imageName), ImageFormat.Jpeg);
                            smallImage.Dispose();
                            b.Dispose();
                            if (hra.Ikona!=null)
                            {
                                try
                                {
                                    System.IO.File.SetAttributes(Server.MapPath("~/uploads/hry/" + hra.Ikona), FileAttributes.Normal);
                                    System.IO.File.Delete(Server.MapPath("~/uploads/hry/" + hra.Ikona));

                                }
                                catch (Exception e)
                                {

                                }

                            }
                          
                            hra.Ikona = imageName;

                        }
                        else
                        {
                            hra.Ikona = Server.MapPath("~´/uploads/hry/" + obrazek.FileName);
                            obrazek.SaveAs(Server.MapPath("~´/uploads/hry/" + obrazek.FileName));
                        }

                       
                     
                        
                    }
                    else
                    {
                        TempData["error"] = "obrázek není jpg / png";
                        return View("EditHra", hra);
                    }

                }
                Vydavatel Vstary = vydavateleDao.GetByGame(hra.Id);
              
                if (hra.Vydavatel.Id !=Vstary.Id)
                {
                    Vydavatel novy = hra.Vydavatel;

                    Vstary.Pocet--;
                    vydavateleDao.Update(Vstary);
                    novy.Pocet++;
                    vydavateleDao.Update(novy);
                }

                Platforma Pstary = platformaDao.GetByGame(hra.Id);
                if (hra.Platforma.Id != Pstary.Id)
                {
                   
                    Platforma novy = hra.Platforma;
                    Pstary.Pocet--;
                    platformaDao.Update(Pstary);
                    hra.Platforma.Pocet++;
                    platformaDao.Update(hra.Platforma);
                }


              
               
             

                gameDao.Update(hra);
                TempData["message-success"] = "Hra " + hra.Nazev + "byla upravena.";
                return RedirectToAction("hra");

            }
            else
            {
                return View("EditHra", hra);
            }
        }


        [HttpPost]
        public ActionResult Add(Hra hra, string _platforma, string _vydavatel, HttpPostedFileBase obrazek)
        {


            // tato zatracená část musí existovat, jinak by  if (ModelState.IsValid) řval, protože viewbagy by byly prázdné
            PlatformaDao platformaDao = new PlatformaDao();
            IList<Platforma> platformy = platformaDao.GetlAll();

            VydavatelDao vydavateleDao = new VydavatelDao();
            IList<Vydavatel> vydavatele = vydavateleDao.GetlAll();
            ViewBag.platformy = platformy;
            ViewBag.vydavatele = vydavatele;


            Vydavatel vyd;
            Platforma plat;
            // hra.Id = new GameDao().getNewId();

            if (ModelState.IsValid)
            {
                vyd = vydavateleDao.GetById(int.Parse(_vydavatel));
                plat = platformaDao.GetById(int.Parse(_platforma));
                hra.Vydavatel = vyd;
                hra.Platforma = plat;
                if (obrazek != null)
                {
                    if (obrazek.ContentType == "image/jpeg" || obrazek.ContentType == "image/png")
                    {
                        Image image = Image.FromStream(obrazek.InputStream);
                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image smallImage = ImageHelper.ScaleImage(image, 200, 200);

                            Bitmap b = new Bitmap(smallImage);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";
                            b.Save(Server.MapPath("~/uploads/hry/" + imageName), ImageFormat.Jpeg);
                            smallImage.Dispose();
                            b.Dispose();
                            
                            hra.Ikona = imageName;

                        }
                        else
                        {
                            obrazek.SaveAs(Server.MapPath("~´/uploads/hry/" + obrazek.FileName));
                        }
                    }
                }
                Vydavatel vydavatel = hra.Vydavatel;
                Platforma platforma = hra.Platforma;
                platforma.Pocet++;
                vydavatel.Pocet++;
                platformaDao.Update(platforma);
                vydavateleDao.Update(vydavatel);
                DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
                hryDao.Create(hra);
              
             
                TempData["message-succes"] = "Hra byla vytvořena";
                return RedirectToAction("hra");
            }
            else
            {
                return RedirectToAction("NovaHra", hra);
            }
        }



        [HttpPost] //aby nikdo nemohl to udělat přes url
        public ActionResult delete(String _id, int? _page, int? _itemsOnPage, bool? vse)
        {
       
            int id =  int.Parse(_id);
            GameDao gameDao= new GameDao();
            Hra hra = gameDao.GetById(id);
            
                            if (hra.Ikona != null)
                            {
                try
                {
                    System.IO.File.SetAttributes(Server.MapPath("~/uploads/hry/" + hra.Ikona), FileAttributes.Normal);
                    System.IO.File.Delete(Server.MapPath("~/uploads/hry/" + hra.Ikona));

                }
                catch (Exception e)
                {

                }

            }

            PlatformaDao platformaDao = new PlatformaDao();

            VydavatelDao vydavateleDao = new VydavatelDao();

            TempData["message-success"] = "Hra " + hra.Nazev + "byla upravena.";
                        Vydavatel vydavatel = hra.Vydavatel;
                        Platforma platforma = hra.Platforma;
                        platforma.Pocet--;
                        vydavatel.Pocet--;
                        platformaDao.Update(platforma);
                        vydavateleDao.Update(vydavatel);
            gameDao.Delete(hra);
            return RedirectToAction("Hra");
        }
        [HttpPost]
      

        public ActionResult deleteObrazek(int hra, int ido)
        {
            ObrazekDao obrazekDao=new ObrazekDao();
            Obrazek smazat = obrazekDao.GetById(ido);
            if (smazat.Ikona != null)
            {
                System.IO.File.SetAttributes(Server.MapPath("~/uploads/hry/" + smazat.Ikona), FileAttributes.Normal);
                System.IO.File.Delete(Server.MapPath("~/uploads/hry/" + smazat.Ikona));

            }
            obrazekDao.Delete(smazat);
            return RedirectToAction("DetailHry", new{id=hra});
        }

    }
           
        }










