using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        public ActionResult Hra(int? _page, int? _itemsOnPage, bool? vse)
        {


            int celkem;
            bool _vse = vse.HasValue ? vse.Value : false;
            int itemsOnPage = _itemsOnPage.HasValue ? _itemsOnPage.Value : Utilityzer.DefaultCountPerPage;
            int page = _page.HasValue ? _page.Value : 1;
            GameDao gameDao = new GameDao();
            IList<Hra> ucty = gameDao.getPaged2(itemsOnPage, page, out celkem, _vse);

            //foreach (Hra item in ucty)
            //{
            //    if (item.Platforma.Aktivovano == false || item.Vydavatel.Aktivovano == false)
            //        ucty.Remove(item);
            //}

           
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
    
        public ActionResult Search(string nazev)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.SearchName3(nazev);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return PartialView("HraAjax", ucty);
        }

        public ActionResult SearchVydavatel(int id)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.GetByVydavatel2(id, out celkem, false);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return View("Hra", ucty);
        }
        public ActionResult SearchPlatforma(int id)
        {
            int celkem;
            GameDao hraDao = new GameDao();
            IList<Hra> ucty = hraDao.GetByPlatforma2(id, out celkem, false);
            celkem = ucty.Count;
            ViewBag.celkem = celkem;
            return View("Hra", ucty);
        }
        public JsonResult searchHrabyNazev(string query)
        {

            DataKnihovna.DAO.GameDao hryDao = new DataKnihovna.DAO.GameDao();
            IList<Hra> hry = hryDao.SearchName3(query);
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


    }
           
        }










