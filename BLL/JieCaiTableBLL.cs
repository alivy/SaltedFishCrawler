using DAL;
using Data.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class JieCaiTableBLL : BaseBLL<JieCaiTable>
    {
        public override void SetDal()
        {
            _baseDal = new JieCaiTableDAL();
        }


        public JieCaiTable QueryTset()
        {
            return (_baseDal as JieCaiTableDAL).QueryTset();
        }
    }
}
