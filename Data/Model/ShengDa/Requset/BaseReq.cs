using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Requset
{
    /// <summary>
    /// 基础请求类
    /// </summary>
    public class BaseReq
    {

        /// <summary>
        /// action
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// session编号
        /// </summary>
        public string session_id { get; set; }
    }
}
