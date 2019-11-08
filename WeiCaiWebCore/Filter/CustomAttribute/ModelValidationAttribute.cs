using Data.Enums;
using Data.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Utils.Expand;

namespace WeiCaiWebCore.Filter.CustomAttribute
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 添加模型权限验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
           
            var modelState = actionContext.Controller.ViewData.ModelState;
            if (modelState.IsValid)
                return;
            var errorMsg = modelState.FristModelStateErrors().FirstOrDefault();
            actionContext.HttpContext.Response.ContentType = "application/json";
            base.OnActionExecuting(actionContext);
            var result = ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg);
            string json = JsonConvert.SerializeObject(result);
            actionContext.HttpContext.Response.Write(json);
            actionContext.HttpContext.Response.End();
            actionContext.HttpContext.Response.Close();
            actionContext.HttpContext.Response.Redirect("/Login/Index");
            actionContext.Result = new RedirectResult("/Login/index");

        }
    }
}
