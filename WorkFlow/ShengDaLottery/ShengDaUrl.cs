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
        public const string DomainName = "http://shengdaweb.u5n2k.cn";
        /// <summary>
        /// 登录地址
        /// </summary>
        public static string LogIn = $"{DomainName}/Home/LoginMain";

        /// <summary>
        /// 彩票类型及编号信息
        /// </summary>
        public static string LotteryCodeInfo = $"{DomainName}/Home/Index";



        /// <summary>
        /// 彩票相关信息查询
        /// </summary>
        public static string LotteryQuery = $"{DomainName}/Home/Buy";

        /// <summary>
        /// 彩票投注结果信息查询
        /// </summary>
        public static string BettingResultQuery = $"{DomainName}/Home/BettingMain";

        /// <summary>
        /// 彩票投注
        /// </summary>
        public static string AddBetting = $"{DomainName}/Home/AddBetting";

    }
}
