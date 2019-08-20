using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ViewModel
{
    public class ResFootMatchBase<T>
    {
        public List<dayRaceVoList<T>> dayRaceVoList { get; set; }

        public List<string> l_cnlist { get; set; }

    }

    public class dayRaceVoList<T>
    {
        public string date { get; set; }

        public string week { get; set; }

        public List<raceVoList<T>> raceVoList { get; set; }
    }

    public class raceVoList<T>
    {
        //  public ResWinOrLose resWinOrLose { set; get; }


        public string id { get; set; }

        public string num { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public string h_cn_abbr { get; set; }

        public string a_cn_abbr { get; set; }

        public string h_order { get; set; }

        public string a_order { get; set; }

        public string weather { get; set; }

        public string temperature { get; set; }

        public string weather_pic { get; set; }

        public string l_cn { get; set; }
        public string l_cn_abbr { get; set; }
        public T bfOdds { get; set; }
      //  public Odds winorloseOdds { get; set; }

        public hadodds hadodds { get; set; }
        public hhadodds hhadodds { get; set; }
        public TotalGoals totalOdds { get; set; }
        public MatchScore scoreOdds { get; set; }
        public HalfCourtNegative halfOdds { get; set; }

    }

    public class Odds
    {
        //public string a { get; set; }

        //public string d { get; set; }

        //public string h { get; set; }

        //public string b { get; set; }
        //public string e { get; set; }
        //public string i { get; set; }
        //public string o_type { get; set; }
        //public string single { get; set; }
        //public string fixedodds { get; set; }
        //public string ro_type { get; set; }
        //public string rsingle { get; set; }
        //public string rfixedodds { get; set; }

        //public hadodds hadodds { get; set; }

        //public hhadodds hhadodds { get; set; }
    }
    public class hadodds
    {
        public string a { get; set; }

        public string d { get; set; }

        public string h { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }

    public class hhadodds
    {
        public string a { get; set; }

        public string d { get; set; }

        public string h { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }
    public class TotalGoals
    {
        public string s0 { get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string s6 { get; set; }
        public string s7 { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }

    public class MatchScore
    {
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string s6 { get; set; }
        public string s7 { get; set; }
        public string s8 { get; set; }
        public string s9 { get; set; }
        public string s10 { get; set; }
        public string s11 { get; set; }
        public string s12 { get; set; }
        public string s13 { get; set; }
        public string s14 { get; set; }
        public string s15 { get; set; }
        public string s16 { get; set; }
        public string s17 { get; set; }
        public string s18 { get; set; }
        public string s19 { get; set; }
        public string s20 { get; set; }
        public string s21 { get; set; }
        public string s22 { get; set; }
        public string s23 { get; set; }
        public string s24 { get; set; }
        public string s25 { get; set; }
        public string s26 { get; set; }
        public string s27 { get; set; }
        public string s28 { get; set; }
        public string s29 { get; set; }
        public string s30 { get; set; }
        public string s31 { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }

    public class HalfCourtNegative
    {
        public string aa { get; set; }
        public string ad { get; set; }
        public string ah { get; set; }
        public string da { get; set; }
        public string dd { get; set; }
        public string dh { get; set; }
        public string ha { get; set; }
        public string hd { get; set; }
        public string hh { get; set; }

        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }
}
