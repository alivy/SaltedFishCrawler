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
                var userMenus = db.Database.SqlQuery<ResWinOrLose>(sql).ToList();
                return userMenus;
            }
        }
    }
}
