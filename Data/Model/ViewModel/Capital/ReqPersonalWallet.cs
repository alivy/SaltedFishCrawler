using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ViewModel.Capital
{
    /// <summary>
    /// 生成个人钱包请求参数
    /// </summary>
   public class ReqPersonalWallet
    {
        [StringLength(50, ErrorMessage = "用户名长度设置过长")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
    }
}
