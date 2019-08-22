using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Cache;
using WeiCaiWebCore.Filter;

namespace WeiCaiWebCore.Controllers
{
    [TokenAuthorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 购买足彩
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyFullLottery(ReqBuyFullLottery req)
        {
            var userId = SessionManager.Get(ConstString.UserLoginId);

            return View();
        }
    }
}