using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using WebSite.Filter;
using Utils.Encrypt;
using Utils.Cache;
using Data.ViewModel;
using Data.Enums;
using Data.Model.DBModel;
using BLL;
using System.IO;
using System.Collections.Generic;

namespace WeiCaiWebCore.Filter
{
    /// <summary>
    /// 验证用户Token
    /// </summary>
    [CompressActionFilter]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //过滤验证
            if (filterContext.ActionDescriptor.IsDefined(typeof(NoTokenCheckAttribute), true) ||
               filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(NoTokenCheckAttribute), true))
                return;
            var token = filterContext.HttpContext.Request.Headers["token"];
            if (!string.IsNullOrWhiteSpace(token))
            {
                var userId = int.Parse(token.Decrypt());
                if (CheckToken(userId))
                {
                    SessionManager.Add(ConstString.UserLoginId, userId);
                    return;
                }
            }
            filterContext.HttpContext.Response.ContentType = "application/json";
            var result = ResMessage.CreatMessage(ResultMessageEnum.Error, "无Token用户权限,请登录获取token");
            filterContext.Result = new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            //string json = JsonConvert.SerializeObject(result);
            //filterContext.HttpContext.Response.Write(json);
            filterContext.HttpContext.Response.End();
            filterContext.HttpContext.Response.Close();
        }

        /// <summary>
        /// 获取缓存用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckToken(int userId)
        {
            return new UserInfoBLL().QueryUserInfoById(userId) != null;
        }


        Dictionary<int, string> openWith = new Dictionary<int, string>();

        /// <summary>
        /// 时间戳校验
        /// </summary>
        /// <param name="context"></param>
        ///    <param name="userId"></param>
        /// <returns>一个bool的数据，表示用户是否拥有其他权限</returns>
        public bool CheckTimeStamp(AuthorizationContext context, string userId)
        {
            bool isAccess = false;
            var controller = context.RouteData.Values.Keys.First(p => p == "controller");
            var action = context.RouteData.Values.Keys.First(p => p == "action");
            var parameter = RequestJsonStr();
            var url = "/" + context.RouteData.Values[controller] + "/" + context.RouteData.Values[action];
            //根据controller和action 可以判断权限了
            if (userId != null)
            {
                isAccess = true;
            }
            return isAccess;
        }

        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <returns></returns>
        public string RequestJsonStr()
        {
            Stream postData = HttpContext.Current.Request.InputStream;
            StreamReader sRead = new StreamReader(postData);
            string postContent = sRead.ReadToEnd();
            sRead.Close();
            return postContent;
        }

    }
}