using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiCaiWebCore.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 接口A
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var obj = new { a = 1 };
            return Json(obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}