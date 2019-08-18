using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ViewModel
{
    /// <summary>
    /// 用户注册请求 
    /// </summary>
    public class ReqUserRegister
    {
        /// <summary>
        /// 用户名
        /// </summary>
        //[StringLength(50, ErrorMessage = "用户名长度设置过长")]
        //[Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "用户密码不能为空")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "密码长度至少是6位")]
        public string PassWord { get; set; }


        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "手机号输入错误")]
        public string Phone { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

    }
}
