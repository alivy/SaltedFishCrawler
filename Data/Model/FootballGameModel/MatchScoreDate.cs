using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FootballGameModel.MatchScore
{
    /// <summary>
    /// 比分数据
    /// </summary>
    public class MatchScoreDate : BaseFootballGame
    {
        public List<data> data { get; set; }

        public status status { get; set; }
    }

    public class data
    {
        /// <summary>
        /// 赛事id
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
        /// 赔率数据
        /// </summary>
        public crs crs { get; set; }
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
        /// 温度
        /// </summary>
        public string temperature { get; set; }
        /// <summary>
        /// 天气图片地址
        /// </summary>
        public string weather_pic { get; set; }
        public List<match_info> match_info { get; set; }
    }
    /// <summary>
    /// 赔率数据
    /// </summary>
    public class crs
    {
        /// <summary>
        /// 负其他
        /// </summary>
        public string s1 { get; set; }
        /// <summary>
        /// 平其他
        /// </summary>
        public string s2 { get; set; }
        /// <summary>
        /// 胜其他
        /// </summary>
        public string s3 { get; set; }
        /// <summary>
        /// 0：0
        /// </summary>
        public string s4 { get; set; }
        /// <summary>
        /// 0：1
        /// </summary>
        public string s5 { get; set; }
        /// <summary>
        /// 0：2
        /// </summary>
        public string s6 { get; set; }
        /// <summary>
        /// 0：3
        /// </summary>
        public string s7 { get; set; }
        /// <summary>
        /// 0：4
        /// </summary>
        public string s8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s11 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s12 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s14 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s15 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s16 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s17 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s19 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s20 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s21 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s22 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s23 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s24 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s25 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s26 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s27 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s28 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s29 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s30 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string s31 { get; set; }
        public string  p_code{ get; set; }
        public string o_type { get; set; }
        public string p_id { get; set; }
        public string p_status { get; set; }
        public string single { get; set; }
        public string allup { get; set; }
        public string goalline { get; set; }
        public string fixedodds { get; set; }
        public string cbt { get; set; }
        public string Int { get; set; }
        public string vbt { get; set; }
        public string h_trend { get; set; }
        public string a_trend { get; set; }
        public string d_trend { get; set; }
        public string l_trend { get; set; }
    }
    public class status
    {
        public string maxcount { get; set; }

        public allup allup { get; set; }

        public string last_updated { get; set; }
    }

}
