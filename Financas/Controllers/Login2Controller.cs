using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class Login2Controller : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            bool Login = WebSecurity.Login(login, senha);

            if (Login)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult LogOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }

    }
}

