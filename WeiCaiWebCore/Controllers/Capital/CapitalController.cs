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
using Utils.Expand;

namespace WeiCaiWebCore.Controllers.Capital
{
    public class CapitalController : Controller
    {
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ActionResult Recharge(ReqConsumptiondetails req)
        {
            if (!ModelState.IsValid)
            {
                var errorMsg = ModelState.FristModelStateErrors().FirstOrDefault();
                return Json(ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg));
            }
            if (req != null)
            {
                var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.UserName.Equals(req.UserName));
                if (userinfo == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                }
                var bll = new CapitalBLL();
                if (req.Amount <= 0)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "充值金额不能小于等于0"));
                }
                bool bl = bll.Recharge(req);
                if (bl)
                {
                    bll.AddBalance(req.UserName, req.Amount);
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "充值成功"));
                }

            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "充值失败"));
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
                var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.UserName.Equals(req.UserName));
                if (userinfo == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                }
                var bll = new CapitalBLL();
                if (req.Amount <= 0)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "提现金额不能小于等于0"));
                }
                bool bl = bll.CashAdvance(req);
                if (bl)
                {
                    bool blz = false;
                    string msg;
                    (blz, msg) =bll.SubtractBalance(req.UserName, req.Amount);
                    if (blz)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "提现成功"));
                    }
                    else
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, msg));
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
                var userinfo = new BaseBLL<UserInfo>().FirstOrDefault(x => x.UserName.Equals(req.UserName));
                if (userinfo == null)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "该用户不存在"));
                }
                var bll = new CapitalBLL();
                if (req.Amount <= 0)
                {
                    return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "金额不能小于等于0"));
                }
                bool bl = bll.Deduction(req);
                if (bl)
                {
                    bool blz = false ;
                    string msg;
                    (blz, msg) = bll.SubtractBalance(req.UserName, req.Amount);
                    if (blz)
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "扣款成功"));
                    }
                    else
                    {
                        return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, msg));
                    }
                  
                }

            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "扣款失败"));
        }
    }
}

