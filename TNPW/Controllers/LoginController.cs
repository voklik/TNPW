using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataKnihovna.DAO;
using DataKnihovna.Model;

namespace TNPW.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string login, string password, bool trvale)
        {

            if (Membership.ValidateUser(login, password))
            {
                Ucet ucet = new UcetDao().GetByLoginAndPassword(login, password);

                if (ucet.Aktivovano == false)
                {
                    TempData["error"] = "Tento účet není aktivní a nemůže být použit při přihlašování";
                    return RedirectToAction("LoginPage");
                }

                if (trvale)
                {
                    FormsAuthentication.SetAuthCookie(login, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(login, false);
                }
            
        
            return RedirectToAction("Index", "Home", new{area=""});
            }

            TempData["error"] = "Login nebo heslo jsou špatně";
            return RedirectToAction("LoginPage");
        }

        public ActionResult SignOut()
        {
            TempData["odhlasen"] = "uživatel byl odhlášen";
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}