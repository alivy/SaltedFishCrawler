using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data.Model.ViewModel
{
    public class ReqFootballMatch
    {
        /// <summary>
        /// 足彩玩法类型
        /// </summary>
        [Required(ErrorMessage = "足彩玩法不能为空")]      
        public int FootballGameType { get; set; }
    }
}
