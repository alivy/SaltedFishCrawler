using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiCaiWebCore.Controllers.BaseAction;

namespace WeiCaiWebCore.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 用于封装返回对象直接转json输出
        /// 
        /// 小知识：使用这些访问修饰符可指定下列五个可访问性级别：
        /// public：访问不受限制。
        /// protected：访问仅限于包含类或从包含类派生的类型。
        /// Internal：访问仅限于当前程序集。
        /// protected internal:访问限制到当前程序集或从包含派生的类型的类别。
        /// private：访问仅限于包含类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        internal RequestActionResult<T> RequestAction<T>(T t) where T : class
        {
            return new RequestActionResult<T>(t);
        }
        /// <summary>
        /// 接口A
        /// </summary>
        /// <returns></returns>
      // [EnableCors(origins: "https://www.baidu.com/",headers:"*",methods: "GET, POST, PUT, DELETE, OPTIONS")]
        public ActionResult Index()
        {
            var obj = new { a = 1 };
            ///封装泛型json数据
            return RequestAction(obj);
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