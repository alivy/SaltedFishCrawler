using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FootballGameModel
{
    /// <summary>
    /// 胜平负数据
    /// </summary>
    public class WinOrLoseDate : BaseFootballGame
    {
        public List<data> data { get; set; }

        public status status { get; set; }
    }

    public class data
    {
        /// <summary>
        /// 赛事ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 赛事编号
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 开赛日期
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 开赛时间
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 开赛日期
        /// </summary>
        public string b_date { get; set; }
        public string status { get; set; }
        public string hot { get; set; }
        public string l_id { get; set; }
        public string l_cn { get; set; }
        public string h_id { get; set; }
        public string h_cn { get; set; }
        public string a_id { get; set; }
        public string a_cn { get; set; }
        public string index_show { get; set; }
        public string show { get; set; }
        /// <summary>
        /// 主队赔率数据
        /// </summary>
        public hhad hhad { get; set; }
        /// <summary>
        /// 客队赔率数据
        /// </summary>
        public had had { get; set; }

        public string l_cn_abbr { get; set; }

        /// <summary>
        /// 主队
        /// </summary>
        public string h_cn_abbr { get; set; }
        /// <summary>
        /// 客队
        /// </summary>
        public string a_cn_abbr { get; set; }
        /// <summary>
        /// 主队球队
        /// </summary>
        public string h_order { get; set; }
        /// <summary>
        /// 客队球队
        /// </summary>
        public string a_order { get; set; }
        public string h_id_dc { get; set; }
        public string a_id_dc { get; set; }
        public string l_background_color { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string weather { get; set; }

        public string weather_city { get; set; }

        /// <summary>
        /// 天气温度
        /// </summary>
        public string temperature { get; set; }

        /// <summary>
        /// 天气图片地址
        /// </summary>
        public string weather_pic { get; set; }

        public List<match_info> match_info { get; set; }

    }

    public class hhad
    {
        /// <summary>
        /// 客队负赔率
        /// </summary>
        public string a { get; set; }
        /// <summary>
        /// 客队打平赔率
        /// </summary>
        public string d{ get; set; }
        /// <summary>
        /// 客队胜赔率
        /// </summary>
        public string h { get; set; }
        public string goalline { get; set; }
        public string p_code { get; set; }
        public string o_type { get; set; }
        public string p_id { get; set; }
        public string p_status { get; set; }
        public string single { get; set; }
        public string allup { get; set; }
        /// <summary>
        /// 客队让球数
        /// </summary>
        public string fixedodds { get; set; }
        public string cbt { get; set; }
        public string Int { get; set; }
        public string vbt { get; set; }
        public string h_trend { get; set; }
        public string a_trend { get; set; }
        public string d_trend { get; set; }
        public string l_trend { get; set; }

    }

    public class had
    {
        /// <summary>
        /// 主队胜赔率
        /// </summary>
        public string a { get; set; }
        /// <summary>
        /// 主队打平赔率
        /// </summary>
        public string d { get; set; }
        /// <summary>
        /// 主队负赔率
        /// </summary>
        public string h { get; set; }

        public string goalline { get; set; }

        public string p_code { get; set; }
        public string o_type { get; set; }
        public string p_id { get; set; }
        public string p_status { get; set; }
        public string single { get; set; }
        public string allup { get; set; }
        public string fixedodds { get; set; }
        public string cbt { get; set; }
        public string Int { get; set; }
        public string vbt { get; set; }
        public string h_trend { get; set; }
        public string a_trend { get; set; }
        public string d_trend { get; set; }
        public string l_trend { get; set; }
   

    }

    public class match_info
    {

    }

    public class status
    {
        public string maxcount { get; set; }
        public allup allup { get; set; }
        public string last_updated { get; set; }
    }

    public class allup
    {

    }
}
