using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace WeiCaiWebCore.Controllers.BaseAction
{
    public class RequestActionResult<T> : ActionResult
    {
        
        public object Data { get; set; }
        public RequestActionResult(T t)
        {
            Data = t;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(Data);
            context.HttpContext.Response.Write(json);
        }
    }
}