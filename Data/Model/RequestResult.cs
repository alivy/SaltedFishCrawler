using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Data.Model
{
    /// <summary>
    /// js请求返回的结果对象
    /// </summary>
    public class RequestResult
    {
        public RequestResult()
            : this(null)
        {
        }

        public RequestResult(string message)
            : this(ResultMessageEnum.Success, message, null)
        {
        }

        public RequestResult(ResultMessageEnum resultType, string message)
            : this(resultType, message, null)
        {
        }

        public RequestResult(ResultMessageEnum resultType, string message, object returnEntity)
        {
            ResultType = resultType;
            Message = message;
            ReturnEntity = returnEntity;
        }

        [ScriptIgnore]
        public ResultMessageEnum ResultType { get; set; }

        public int ResultTypeId { get { return (int)ResultType; } set { ResultType = (ResultMessageEnum)value; } }

        public string Message { get; set; }

        public object ReturnEntity { get; set; }

        public static RequestResult Success()
        {
            return new RequestResult();
        }

        public static RequestResult Success(string message)
        {
            return new RequestResult(message);
        }

        public static RequestResult Success(string message, object entity)
        {
            return new RequestResult(ResultMessageEnum.Success, message, entity);
        }

        public static RequestResult Success(object entity)
        {
            return new RequestResult(ResultMessageEnum.Success, null, entity);
        }

        public static RequestResult Error(string message)
        {
            return new RequestResult(ResultMessageEnum.Error, message);
        }

        public static RequestResult Error()
        {
            return new RequestResult(ResultMessageEnum.Error, null);
        }

        public static RequestResult Error(string message, object entity)
        {
            return new RequestResult(ResultMessageEnum.Error, message, entity);
        }

        public static RequestResult Exception(string message)
        {
            return new RequestResult(ResultMessageEnum.Exception, message);
        }

        public static RequestResult ValidateError()
        {
            return new RequestResult(ResultMessageEnum.ValidateError, null);
        }

        public static RequestResult ValidateError(string message)
        {
            return new RequestResult(ResultMessageEnum.ValidateError, message);
        }

        public static RequestResult ValidateError(string message, string entity)
        {
            return new RequestResult(ResultMessageEnum.ValidateError, message, entity);
        }
    }
}
