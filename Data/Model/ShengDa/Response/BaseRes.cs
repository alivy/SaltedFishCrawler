using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Response
{
    /// <summary>
    /// 基础响应类
    /// </summary>
    public class BaseRes<T>
    {
        /// <summary>
        /// 响应编号 1代表成功
        /// </summary>
        public int Code { get; set; }

        public T data { get; set; }

        public string StrCode { get; set; }
    }
}
