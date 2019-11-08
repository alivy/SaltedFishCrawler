using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiCaiWebCore.Filter
{
    /// <summary>
    /// 全局筛选器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class OverallActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }


        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", filterContext.HttpContext.Request.RawUrl);
            //filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");
        }
    }
}