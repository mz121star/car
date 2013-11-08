using car.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public ActionResult Index(int? viewType)
        {

            var categoryList = services.GetAllGoodsCategory();
            var typeList = new List<SecondGoods>();

            foreach (var item in categoryList.RESULT)
            {
                var type = services.GetGoodsTypeByCategoryID(item.GOODSCATEGORYID);
                type.RESULT.ToList().ForEach(x => x.FIRSTID = item.GOODSCATEGORYID);
                typeList.AddRange(type.RESULT);
            }

            dynamic tree = new ExpandoObject();
            tree.FirstList = categoryList.RESULT;
            tree.SecondList = typeList;
            tree.ViewType = null;

            return View(tree);
        }

        public ActionResult LoadGoods(string typeId, int? viewType)
        {
            dynamic tree = new ExpandoObject();
            var b = services.GetGoodsByTypeID(typeId).RESULT;
            tree.ViewType = viewType ?? 1;
            tree.Goods = b;
            return PartialView("Partial/_RightViewGrid", tree);
        }

        [SessionUserParameter]
        public ActionResult Car()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginMethod(string name, string password)
        {
            var user = services.Login(name, password);
            Session["Plate"] = null;
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.Write("<script>alert('用户名或者密码错误!');</script>");
                return View("Login");
            }
        }

        [SessionUserParameter]
        public ActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            Session["user"] = null;
            Session["Plate"] = null;
            Session["SalesId"] = null;
            return View("Login");
        }

        [SessionUserParameter]
        public JsonResult GetAllPlate()
        {
            return Json(services.GetAllPlate().RESULT, JsonRequestBehavior.AllowGet);
        }

        [SessionUserParameter]
        public JsonResult SetPlate(string plate, string salesId)
        {
            var detail = services.DownloadBill(salesId);
            Session["Plate"] = plate;
            Session["SalesId"] = salesId;
            return Json(detail.DETAIL, JsonRequestBehavior.AllowGet);
        }

        [SessionUserParameter]
        public JsonResult DeleteGoods(string goodsId)
        {
            var salesId = Session["SalesId"].ToString();
            var message = services.DeleteGoods(salesId, goodsId);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddGoods()
        {
            GoodsDetailList list = new GoodsDetailList();
            list.DETAIL = new List<GoodsDetail>();
            list.DETAIL.Add(new GoodsDetail { GOODSID = "1" });
            var message = services.AddGoods(list);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [SessionUserParameter]
        public ActionResult DeleteBill()
        {
            var salesId = Session["SalesId"].ToString();
            var message = services.DeleteBill(salesId);
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}
