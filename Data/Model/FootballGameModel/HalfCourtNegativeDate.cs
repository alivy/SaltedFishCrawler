using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FootballGameModel.HalfCourtNegative
{
    /// <summary>
    /// 半全场平负数据
    /// </summary>
    public class HalfCourtNegativeDate : BaseFootballGame
    {
        /// <summary>
        /// 赛事数据
        /// </summary>
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
        public hafu hafu { get; set; }
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

    public class hafu
    {
        /// <summary>
        /// 负负赔率
        /// </summary>
        public string aa { get; set; }
        /// <summary>
        /// 负平赔率
        /// </summary>
        public string ad { get; set; }
        /// <summary>
        /// 负胜赔率
        /// </summary>
        public string ah { get; set; }
        /// <summary>
        /// 平负赔率
        /// </summary>
        public string da { get; set; }
        /// <summary>
        /// 平平赔率
        /// </summary>
        public string dd { get; set; }
        /// <summary>
        /// 平胜赔率
        /// </summary>
        public string dh { get; set; }
        /// <summary>
        /// 胜负赔率
        /// </summary>
        public string ha { get; set; }
        /// <summary>
        /// 胜平赔率
        /// </summary>
        public string hd { get; set; }
        /// <summary>
        /// 胜胜赔率
        /// </summary>
        public string hh { get; set; }
        public string p_code { get; set; }
        public string o_type { get; set; }
        public string p_id { get; set; }
        public string p_status { get; set; }
        public string single { get; set; }
        public string allup { get; set; }
        public string goalline { get; set; }
        public string fixedodds { get; set; }
        public string cbt { get; set; }
        public string Int { get; set; }//字段原本为小写
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
