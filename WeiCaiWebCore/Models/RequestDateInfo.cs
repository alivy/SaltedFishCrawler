using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiCaiWebCore.Models
{
    public class RequestDateInfo
    {
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// action名字
        /// </summary>
        public string ActionName { get; set; }
    }
}