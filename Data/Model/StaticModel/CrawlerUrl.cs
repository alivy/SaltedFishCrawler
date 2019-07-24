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
        public static Dictionary<FootballGameTypeEnum, string> FootballDir = new Dictionary<FootballGameTypeEnum, string>()
        {
            { FootballGameTypeEnum.WinOrLose,"https://info.sporttery.cn/football/hhad_list.php" },
            { FootballGameTypeEnum.LetBallWinOrLose,"https://info.sporttery.cn/football/hhad_list.php" },
            { FootballGameTypeEnum.Score,"https://info.sporttery.cn/football/cal_crs.htm" },
            { FootballGameTypeEnum.TotalGoals,"https://info.sporttery.cn/football/cal_ttg.htm" },
            { FootballGameTypeEnum.HalfCourtNegative,"https://info.sporttery.cn/football/cal_hafu.htm" },
            { FootballGameTypeEnum.MixedCustoms,"https://info.sporttery.cn/mixed/mixed.htm?gameIndex=0" },
        };

        /// <summary>
        /// 竞彩足球赛事数据地址
        /// </summary>
        public static Dictionary<FootballGameTypeEnum, string> FootballDataDir = new Dictionary<FootballGameTypeEnum, string>()
        {
            { FootballGameTypeEnum.WinOrLose,"https://i.sporttery.cn/odds_calculator/get_odds?i_format=json&i_callback=getData&poolcode[]=hhad&poolcode[]=had&_={0}" },
            { FootballGameTypeEnum.LetBallWinOrLose,"https://i.sporttery.cn/odds_calculator/get_odds?i_format=json&i_callback=getData&poolcode[]=hhad&poolcode[]=had&_={0}" },
            { FootballGameTypeEnum.Score,"https://i.sporttery.cn/odds_calculator/get_odds?i_format=json&i_callback=getData&poolcode[]=crs&_={0}" },
            { FootballGameTypeEnum.TotalGoals,"https://i.sporttery.cn/odds_calculator/get_odds?i_format=json&i_callback=getData&poolcode[]=ttg&_={0}" },
            { FootballGameTypeEnum.HalfCourtNegative,"https://i.sporttery.cn/odds_calculator/get_odds?i_format=json&i_callback=getData&poolcode[]=hafu&_={0}" },
            { FootballGameTypeEnum.MixedCustoms,"https://info.sporttery.cn/mixed/mixed.htm?gameIndex=0" },
        };
    }
}
