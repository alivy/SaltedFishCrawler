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
        public string id { get; set; }
        public string num { get; set; }
        public string date { get; set; }
        public string time { get; set; }
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
        public hhad hhad { get; set; }

        public had had { get; set; }

        public string l_cn_abbr { get; set; }

        public string h_cn_abbr { get; set; }
        public string a_cn_abbr { get; set; }
        public string h_order { get; set; }
        public string a_order { get; set; }
        public string h_id_dc { get; set; }
        public string a_id_dc { get; set; }
        public string l_background_color { get; set; }

        public string weather { get; set; }

        public string weather_city { get; set; }

        public string temperature { get; set; }

        public List<match_info> match_info { get; set; }

    }

    public class hhad
    {
        public string a { get; set; }
        public string d{ get; set; }
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

    public class had
    {
        public string a { get; set; }
        public string d { get; set; }

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
