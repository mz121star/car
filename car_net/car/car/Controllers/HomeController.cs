using car.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace car.Controllers
{
    public class HomeController : Controller
    {
        private Services services = new Services();
        [SessionUserParameter]
        //[Authorize]
        public ActionResult Index()
        {

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            Master master = new Master()
            {
                EMPLOYEEID = "1",
                PLATE = "2",
                SALESID = "3"
            };

            Detail detail = new Detail()
            {
                GOODSID = "4",
                REMARKS = "5",
                SUMNUMBER = "6"
            };
            IList<Master> listMaster = new List<Master>();
            listMaster.Add(master);

            IList<Detail> listDetail = new List<Detail>();
            listDetail.Add(detail);

            MasterDetail md = new MasterDetail()
            {
                MASTER = listMaster,
                DETAIL = listDetail
            };

            services.UploadBillData(md);

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
        public RedirectToRouteResult LoginMethod(string name, string password)
        {
            var user = services.Login(name, password);

            if (user != null)
            {
                Session["user"] = user;
                //FormsAuthentication.SetAuthCookie(user.EMPLOYEENAME, false);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Home");
        }

        public ActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            Session["user"] = null;
            return View("Login");
        }
    }
}
