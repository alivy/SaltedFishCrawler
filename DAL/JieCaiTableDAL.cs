using Data.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JieCaiTableDAL : BaseDal<JieCaiTable>
    {
        public JieCaiTable QueryTset()
        {
            using (var db = DBContext.CreateContext())
            {
                var m_jc = db.JieCaiTable.Where(m => m.Id == 1).SingleOrDefault();
                if (m_jc == null)
                {
                    return null;
                }
                //db.JieCaiTable.Remove(m_jc);
                return m_jc;
            }
        }
    }
}
