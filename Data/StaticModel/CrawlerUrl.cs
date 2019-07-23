using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.StaticModel
{
    /// <summary>
    /// Crawler
    /// </summary>
    public class CrawlerUrl
    {
        

        /// <summary>
        /// 竞彩足球地址
        /// </summary>
        public Dictionary<FootballGameTypeEnum, string> FootballDir = new Dictionary<FootballGameTypeEnum, string>()
        {
            { FootballGameTypeEnum.WinOrLose,"https://info.sporttery.cn/football/hhad_list.php" },
            { FootballGameTypeEnum.LetBallWinOrLose,"https://info.sporttery.cn/football/hhad_list.php" },
            { FootballGameTypeEnum.Score,"https://info.sporttery.cn/football/cal_crs.htm" },
            { FootballGameTypeEnum.TotalGoals,"https://info.sporttery.cn/football/cal_ttg.htm" },
            { FootballGameTypeEnum.DoubleResult,"https://info.sporttery.cn/football/cal_hafu.htm" },
            { FootballGameTypeEnum.MixedCustoms,"https://info.sporttery.cn/mixed/mixed.htm?gameIndex=0" },
        };


    }
}
