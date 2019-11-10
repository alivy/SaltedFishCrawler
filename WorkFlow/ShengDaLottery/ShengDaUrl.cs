using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.ShengDaLottery
{
    /// <summary>
    /// 盛大彩票地址
    /// </summary>
    public class ShengDaUrl
    {
        /// <summary>
        /// 登录地址
        /// </summary>
        public const string LogIn = "https://shengdaweb.0451pz.com/Home/LoginMain";

        /// <summary>
        /// 彩票类型及编号信息
        /// </summary>
        public const string LotteryCodeInfo = "https://shengdaweb.0451pz.com/Home/Index";


        /// <summary>
        /// 彩票相关信息查询
        /// </summary>
        public const string LotteryQuery = "https://shengdaweb.0451pz.com/Home/Buy";

        /// <summary>
        /// 彩票投注结果信息查询
        /// </summary>
        public const string BettingResultQuery = "https://shengdaweb.0451pz.com/Home/BettingMain";
    }
}
