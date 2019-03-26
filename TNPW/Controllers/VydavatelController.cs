using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class VydavatelController : Controller
    {
        // GET: Vydavatel
        public ActionResult Vydavatel()
        {
            {
                DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();
                IList<DataKnihovna.Model.Vydavatel> hry = vydavatelDao.GetlAll();

                return View(hry);
            }
        }

        public ActionResult NovyVydavatel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add( Vydavatel vydavatel)
        {
            DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();
       
            if (ModelState.IsValid)
            {

                vydavatelDao.Create(vydavatel);
                return RedirectToAction("Vydavatel");
            }
            else
            {
                return View("NovyVydavatel", vydavatel);
            }
        }

        public ActionResult EditVydavatel(string _id)
        {
            {
                DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();
                Vydavatel vydavatel = vydavatelDao.GetById(int.Parse(_id));

                return View(vydavatel);
            }
        }
        [HttpPost]
        public ActionResult Update(Vydavatel vydavatel)
        {
            DataKnihovna.DAO.VydavatelDao vydavatelDao = new DataKnihovna.DAO.VydavatelDao();

            if (ModelState.IsValid)
            {

                vydavatelDao.Update(vydavatel);
                return RedirectToAction("Vydavatel");
            }
            else
            {
                return View("EditVydavatel", vydavatel);
            }
        }

        [HttpPost]
        public ActionResult Delete(string _id)
        {
            VydavatelDao vydavatelDao = new VydavatelDao();
            Vydavatel vydavatel = vydavatelDao.GetById(int.Parse(_id));

            vydavatelDao.Delete(vydavatel);
                return View("Vydavatel");
            
        }







    }
}