using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Filter
{
    /// <summary>
    /// 允许通过的接口
    /// </summary>
    public class NoTokenCheckAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 只做权限验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.RouteData.Values.Keys.First(p => p == "controller");
            var action = filterContext.RouteData.Values.Keys.First(p => p == "action");

        }
    }
}