using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ViewModel
{
    /// <summary>
    /// 用户登录请求 
    /// </summary>
    public class ReqUserLogin
    {
        /// <summary>
        /// 账号 手机号/邮箱
        /// </summary>
        [StringLength(50, ErrorMessage = "用户名长度设置过长")]
        [Required(ErrorMessage = "账号不能为空")]
        public string account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "用户密码不能为空")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "密码长度至少是6位")]
        public string pwd { get; set; }
    }
}
