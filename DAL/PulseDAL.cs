using Data.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Help;

namespace DAL
{
    public class PulseDAL : BaseDal<Q_Pulse>
    {

        /// <summary>
        /// 获取脉冲编号
        /// </summary>
        /// <returns></returns>
        public int PulseNo(string Name)
        {
            int result = 0;
            //第二，可以用这种方式声明，简单明了
            SqlParameter[] m_parms = new SqlParameter[2]
            {
                new SqlParameter("@Name",Name),
                new SqlParameter("@pnum",result)
            };
            m_parms[1].Direction = System.Data.ParameterDirection.Output;
            string sql2 = $"exec Pro_GetPulse @Name,output @pnum";
            using (var db = DBContext.CreateContext())
            {
                db.Database.ExecuteSqlCommand(sql2, m_parms);
                db.Database.Log = (x) => Log.Write(LogLevel.Info, x); ///这个是获取db的sql执行代码，内部委托
                return result = Convert.ToInt32(m_parms[1].Value);
            }
        }
    }
}
