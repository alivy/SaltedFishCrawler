using Data.Model.DBModel;
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
    }
}
