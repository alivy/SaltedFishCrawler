using BLL;
using Data.Enums;
using Data.Model.DBModel;
using Data.Model.ViewModel.Capital;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Cache;
using Utils.Expand;
using WeiCaiWebCore.Filter;

namespace WeiCaiWebCore.Controllers.Capital
{
    [TokenAuthorize]
    public class CapitalController : Controller
    {
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ActionResult Recharge(ReqConsumptiondetails req)
        {
            object Lock = new object();
            lock (Lock)
            {
                if (!ModelState.IsValid)
                {
                    var errorMsg = ModelState.FristModelStateErrors().FirstOrDefault();
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg));
                }
                if (req != null)
                {
                    var userId = Convert.ToInt32(SessionManager.Get(ConstString.UserLoginId).ToString());
                    var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.Id.Equals(userId));
                    var personalWallet = new BaseBLL<PersonalWallet>().FirstOrDefault(x => x.UserName.Equals(userId.ToString()));
                    if (userinfo == null)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                    }
                    var bll = new CapitalBLL();
                    if (req.Amount <= 0)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "充值金额不能小于等于0"));
                    }
                    if (personalWallet == null)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "用户钱包不存在"));
                    }
                    bool bl = bll.Recharge(req, userId.ToString());
                    if (bl)
                    {
                        bool blz = bll.AddBalance(userId.ToString(), req.Amount);
                        if (blz)
                        {
                            return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "充值成功"));
                        }
                    }
                }
                return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "充值失败"));
            }
           
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ActionResult CashAdvance(ReqConsumptiondetails req)
        {
            if (!ModelState.IsValid)
            {
                var errorMsg = ModelState.FristModelStateErrors().FirstOrDefault();
                return Json(ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg));
            }
            if (req != null)
            {
                var userId = Convert.ToInt32(SessionManager.Get(ConstString.UserLoginId).ToString());
                var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.Id.Equals(userId));
                var personalWallet = new BaseBLL<PersonalWallet>().FirstOrDefault(x => x.UserName.Equals(userId.ToString()));
                if (userinfo == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                }
                var bll = new CapitalBLL();
                if (req.Amount <= 0)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "提现金额不能小于等于0"));
                }
                if (personalWallet == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "用户钱包不存在"));
                }
                if (personalWallet.Balance < req.Amount)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "余额不足"));
                }
                bool bl = bll.CashAdvance(req,userId.ToString());
                if (bl)
                {
                    bool blz =bll.SubtractBalance(userId.ToString(), req.Amount);
                    if (blz)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "提现成功"));
                    }
                }
            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "提现失败"));
        }

        public ActionResult Deduction(ReqConsumptiondetails req)
        {
            if (!ModelState.IsValid)
            {
                var errorMsg = ModelState.FristModelStateErrors().FirstOrDefault();
                return Json(ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg));
            }
            if (req != null)
            {
                var userId =Convert.ToInt32(SessionManager.Get(ConstString.UserLoginId).ToString());
                var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.Id.Equals(userId));
                var personalWallet = new BaseBLL<PersonalWallet>().FirstOrDefault(x => x.UserName.Equals(userId.ToString()));
                if (userinfo == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                }
                var bll = new CapitalBLL();
                if (req.Amount <= 0)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "金额不能小于等于0"));
                }
                if(personalWallet==null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "用户钱包不存在"));
                }
                if (personalWallet.Balance < req.Amount)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "余额不足"));
                }
                bool bl = bll.Deduction(req,userId.ToString());
                if (bl)
                {
                    bool blz = bll.SubtractBalance(userId.ToString(), req.Amount);
                    if (blz)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "扣款成功"));
                    }
                }
            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "扣款失败"));
        }
    }
}

