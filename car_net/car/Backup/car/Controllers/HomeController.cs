using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace car.Controllers
{
    public class HomeController : Controller
    {
        private Services services = new Services();
        [SessionUserParameter]
        public ActionResult Index()
        {
            
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Car()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult LoginMethod(string name,string password)
        {
           var user= services.Login(name, password);

            if (user != null)
            {
                Session["user"] = user;
          
                 return RedirectToAction("Index","Home");
            }

            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public RedirectToRouteResult LogoutMethod()
        {

            Session["user"] = null;
            return RedirectToAction("Login");



        }
    }
}
