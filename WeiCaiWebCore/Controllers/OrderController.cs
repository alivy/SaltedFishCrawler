using BLL;
using Data.Enums;
using Data.Model.DBModel;
using Data.Model.ViewModel;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Cache;
using Utils.Help;
using WeiCaiWebCore.Filter;

namespace WeiCaiWebCore.Controllers
{
    [TokenAuthorize]
    public class OrderController : Controller
    {
        /// <summary>
        /// 脉冲号
        /// </summary>
        private static PulseBLL pulseBLL;

        /// <summary>
        /// 订单号
        /// </summary>
        private static BaseBLL<UserOrder> userOrderBaseBLL;
        /// <summary>
        /// 投注详情表
        /// </summary>
        private static BaseBLL<BetProductDetails> betProductDetailsBaseBLL;
        /// <summary>
        /// 订单商品关联表
        /// </summary>
        private static BaseBLL<OrderProductInfoMapping> orderProductInfoBaseBLL;


        public OrderController()
        {
            pulseBLL = new PulseBLL();
        }


        /// <summary>
        /// 购买足彩
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyFullLottery(ReqBuyFullLottery req)
        {
            if (req.Content.Count() == 0 || !req.Content.Any())
            {
                return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "投注内容信息不能为空"));
            }
            var userId = SessionManager.Get(ConstString.UserLoginId).ObjToInt();
            var orderNo = pulseBLL.GetOrderNoByName("ZQC8", userId);
            userOrderBaseBLL.AddEntity(new UserOrder
            {
                OrderNo = orderNo,
                UserId =userId,
                CopePayMoney =1,
                ActualPayMoney=1,
                State =1,
                CreateTime =DateTime.Now
            });
            var order = new UserOrder();
            return View();
        }


        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public ActionResult QueryOrderInfo(string OrderNo)
        {
            var userId = SessionManager.Get(ConstString.UserLoginId);

            return View();
        }
    }
}