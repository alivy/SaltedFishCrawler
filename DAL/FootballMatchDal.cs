using Data.Model.DBModel;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
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
                                            c.a b,
                                            c.d e,
                                            c.h i
                                             from tblFootballMatch a 
                                            left join tblWinOrLosehad b on a.id=b.id
                                            left join tblWinOrLosehhad c on a.id=c.id");
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
                var half = db.Database.SqlQuery<ResHalfCourtNegative>(sql).ToList();
                return half;
            }
        }
        
    }
}
