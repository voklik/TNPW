using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna;
using DataKnihovna.DAO;
using DataKnihovna.Model;
using NHibernate.Mapping;
using TNPW.utility;

namespace TNPW.Controllers
{
    public class HraController : Controller
    {
        // GET: Hra
        public ActionResult Hra()
        {
            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            IList<DataKnihovna.Model.Hra> hry = hryDao.GetlAll();
        
            return View(hry);
        }
        public ActionResult DetailHry(int id)
        {
            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            DataKnihovna.Model.Hra hra = hryDao.GetById(id);
           
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
                    if (obrazek.ContentType=="image/jpeg"|| obrazek.ContentType=="image/png")
                    {
                        Image image = Image.FromStream(obrazek.InputStream);
                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image smallImage = ImageHelper.ScaleImage(image, 200, 200);

                            Bitmap b = new Bitmap(smallImage);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";
                            b.Save(Server.MapPath("~/uploads/hry/"+imageName),ImageFormat.Jpeg);
                            smallImage.Dispose();
                            b.Dispose();
                            ;
                            hra.Ikona = imageName;
                            
                        }
                        else
                        {
                            obrazek.SaveAs(Server.MapPath("~´/uploads/hry/" + obrazek.FileName));
                        }
                    }
                }
            
                DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            hryDao.Create(hra);
            TempData["message-succes"] = "Hra byla vytvořena";
             return RedirectToAction("Hra");
            }
            else
            {
                return View("NovaHra", hra);
            }
        }

    }
    
}