using Data.Model.DBModel;
using Data.Model.ViewModel;
using Data.Model.ViewModel.MathOrOdds;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FootballMatchDal : BaseDal<tblFootballMatch>
    {
        public tblFootballMatch GetMatchInfo(string id)
        {
            using (var db = DBContext.CreateContext())
            {
                var m_jc = db.tblFootballMatch.Where(m => m.id == id).SingleOrDefault();
                if (m_jc == null)
                {
                    return null;
                }
                return m_jc;
            }
        }
        public List<ResWinOrLose> GetWinOrLoseList()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"select 
                                            a.id,
                                            a.num,
                                            a.date,
                                            a.time,
                                            a.h_cn_abbr,
                                            a.a_cn_abbr,
                                            a.h_order,
                                            a.a_order,
                                            a.weather,
                                            a.temperature,
                                            a.weather_pic,
                                            b.a,
                                            b.d,
                                            b.h,
                                            b.b,
                                            b.e,
                                            b.i 
                                             from tblFootballMatch a 
                                            left join tblWinOrLosehad b on a.id=b.id");
                var winOrLose = db.Database.SqlQuery<ResWinOrLose>(sql).ToList();
                return winOrLose;
            }
        }

        public List<ResTotalGoals> GetTotalGoalsList()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"select 
                                            a.id,
                                            a.num,
                                            a.date,
                                            a.time,
                                            a.h_cn_abbr,
                                            a.a_cn_abbr,
                                            a.h_order,
                                            a.a_order,
                                            a.weather,
                                            a.temperature,
                                            a.weather_pic,
                                            b.s0,
                                            b.s1,
                                            b.s2,
                                            b.s3,
                                            b.s4,
                                            b.s5,
                                            b.s6,
                                            b.s7
                                             from tblFootballMatch a 
                                            left join tblTotalGoalsttg b on a.id=b.id");
                var totalGoals = db.Database.SqlQuery<ResTotalGoals>(sql).ToList();
                return totalGoals;
            }
        }

        public List<ResMatchScore> GetMatchScoreList()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"select 
                                            a.id,
                                            a.num,
                                            a.date,
                                            a.time,
                                            a.h_cn_abbr,
                                            a.a_cn_abbr,
                                            a.h_order,
                                            a.a_order,
                                            a.weather,
                                            a.temperature,
                                            a.weather_pic,
                                            b.s1 ,
                                            b.s2 ,
                                            b.s3 ,
                                            b.s4 ,
                                            b.s5 ,
                                            b.s6 ,
                                            b.s7 ,
                                            b.s8 ,
                                            b.s9 ,
                                            b.s10,
                                            b.s11,
                                            b.s12,
                                            b.s13,
                                            b.s14,
                                            b.s15,
                                            b.s16,
                                            b.s17,
                                            b.s18,
                                            b.s19,
                                            b.s20,
                                            b.s21,
                                            b.s22,
                                            b.s23,
                                            b.s24,
                                            b.s25,
                                            b.s26,
                                            b.s27,
                                            b.s28,
                                            b.s29,
                                            b.s30
                                             from tblFootballMatch a 
                                            left join tblMatchScorecrs b on a.id=b.id");
                var matchScore = db.Database.SqlQuery<ResMatchScore>(sql).ToList();
                return matchScore;
            }
        }

        public List<ResHalfCourtNegative> GetHalfCourtNegativeList()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"select 
                                            a.id,
                                            a.num,
                                            a.date,
                                            a.time,
                                            a.h_cn_abbr,
                                            a.a_cn_abbr,
                                            a.h_order,
                                            a.a_order,
                                            a.weather,
                                            a.temperature,
                                            a.weather_pic,
                                            b.aa,
                                            b.ad,
                                            b.ah,
                                            b.da,
                                            b.dd,
                                            b.dh,
                                            b.ha,
                                            b.hd,
                                            b.hh
                                             from tblFootballMatch a 
                                            left join tblHalfCourtNegativehafu b on a.id=b.id");
                var half = db.Database.SqlQuery<ResHalfCourtNegative>(sql).ToList();
                return half;
            }
        }

        public List<ResMatchOrOdds> GetAllMatchOrOdds()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"SELECT a.id, a.num, a.date, a.time, a.h_cn_abbr
	                                        , a.a_cn_abbr, a.h_order, a.a_order, a.weather, a.temperature
	                                        , a.weather_pic, a.l_cn, a.l_cn_abbr, b.a, b.d
	                                        , b.h, b.b, b.e, b.i, c.s0 AS ss0
	                                        , c.s1 AS ss1, c.s2 AS ss2, c.s3 AS ss3, c.s4 AS ss4, c.s5 AS ss5
	                                        , c.s6 AS ss6, c.s7 AS ss7, d.s1, d.s2, d.s3
	                                        , d.s4, d.s5, d.s6, d.s7, d.s8
	                                        , d.s9, d.s10, d.s11, d.s12, d.s13
	                                        , d.s14, d.s15, d.s16, d.s17, d.s18
	                                        , d.s19, d.s20, d.s21, d.s22, d.s23
	                                        , d.s24, d.s25, d.s26, d.s27, d.s28
	                                        , d.s29, d.s30, e.aa, e.ad, e.ah
	                                        , e.da, e.dd, e.dh, e.ha, e.hd
	                                        , e.hh
                                        FROM tblFootballMatch a
	                                        LEFT JOIN tblWinOrLosehad b ON a.id = b.id
	                                        LEFT JOIN tblTotalGoalsttg c ON a.id = c.id
	                                        LEFT JOIN tblMatchScorecrs d ON a.id = d.id
	                                        LEFT JOIN tblHalfCourtNegativehafu e ON a.id = e.id");
                var matchorodds = db.Database.SqlQuery<ResMatchOrOdds>(sql).ToList();
                return matchorodds;
            }
        }

        public List<ResWinOrLose> Getl_cnList()
        {
            using (var db = DBContext.CreateContext())
            {
                string sql = string.Format(@"SELECT l_cn_abbr
                                        FROM tblFootballMatch group by l_cn_abbr");
                var matchorodds = db.Database.SqlQuery<ResWinOrLose>(sql).ToList();
                return matchorodds;
            }
        }
    }
}
