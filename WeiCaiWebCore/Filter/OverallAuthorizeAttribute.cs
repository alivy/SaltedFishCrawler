using Data.Enums;
using Data.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Cache;
using WeiCaiWebCore.Models;

namespace WeiCaiWebCore.Filter
{
    /// <summary>
    /// 全局权限异常处理
    /// </summary>
    public class OverallAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var msg = string.Empty;
            var checkCookie = CheckCookie(filterContext);
            if (checkCookie.Item1)
                return;
            msg = checkCookie.Item2;
            filterContext.HttpContext.Response.ContentType = "application/json";
            var result = ResMessage.CreatMessage(ResultMessageEnum.Error, msg);
            string json = JsonConvert.SerializeObject(result);
            filterContext.HttpContext.Response.Write(json);
            filterContext.HttpContext.Response.End();
            filterContext.HttpContext.Response.Close();
        }

        /// <summary>
        /// 检查cookie
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        private (bool, string) CheckCookie(AuthorizationContext filterContext)
        {
            string strCooike = string.Empty;
            string cookieKey = "uuid";
            var uuid = HttpContext.Current.Request.Cookies[cookieKey];
            if (uuid != null)
                strCooike = HttpContext.Current.Request.Cookies[cookieKey].Value ?? string.Empty;
            if (string.IsNullOrWhiteSpace(strCooike))
                return (false, "cookie错误");
            var date = uuid.Expires;
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var cacheCookie = CacheManager.GetData<List<RequestDateInfo>>(strCooike) ?? new List<RequestDateInfo>();
            if (cacheCookie != null)
            {
                var reqInfo = cacheCookie.FirstOrDefault(x => x.ActionName.Equals(action) && x.ControllerName.Equals(controller));
                if (reqInfo != null)
                {
                    var diffSeconds = (DateTime.Now - reqInfo.RequestDate).TotalSeconds;
                    if (diffSeconds < 2)
                        return (false, "你的请求过于频繁");
                }
                cacheCookie.Remove(reqInfo);
            }
            cacheCookie.Add(new RequestDateInfo { RequestDate = DateTime.Now, ControllerName = controller, ActionName = action });
            CacheManager.Add(strCooike, cacheCookie, 600);

            return (true, string.Empty);
        }
    }
}