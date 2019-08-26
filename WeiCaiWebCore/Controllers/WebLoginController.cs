using BLL;
using Data.Enums;
using Data.Model.ViewModel;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Cache;
using Utils.Encrypt;
using Utils.Expand;
using WeiCaiWebCore.Filter;
using WebSite.Filter;
using WeiCaiWebCore.Controllers.WebLoginAction;
using WeiCaiWebCore.Filter.CustomAttribute;

namespace WeiCaiWebCore.Controllers
{
    [TokenAuthorize]
    public class WebLoginController : Controller
    {
        private static UserInfoBLL user = new UserInfoBLL();
        // GET: WebLogin
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [ModelValidation, NoTokenCheck]
        public ActionResult LoginIn(ReqUserLogin userLogin)
        {
            var chekUser = user.CheckLogin(userLogin);
            if (!chekUser.Item1)
                return Json(ResMessage.CreatMessage(ResultMessageEnum.AuthorityCheck, "用户或密码错误"));
            int userId = chekUser.Item2;
            SessionManager.Add(ConstString.UserLoginId, userId);
            var token = userId.ToString().Encrypt();
            var obj = new { token };
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "登录成功", obj));
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [ModelValidation, NoTokenCheck]
        public ActionResult Register(ReqUserRegister userRegister)
        {
            var check = RegisterAction.UserRegisterCheck(userRegister);
            if (!check.Item1)
                return Json(ResMessage.CreatMessage(ResultMessageEnum.AuthorityCheck, "用户手机号或邮箱已注册"));
            int userId = check.Item2;
            SessionManager.Add(ConstString.UserLoginId, userId);
            var token = userId.ToString().Encrypt();
            var obj = new { token };
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Success, "注册成功", obj));
        }

    }
}