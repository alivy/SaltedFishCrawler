using DAL;
using Data.Model.DBModel;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Cache;
using Utils.Encrypt;
using Utils.Help;

namespace BLL
{
    public class PulseBLL : BaseBLL<Q_Pulse>
    {
        public override void SetDal()
        {
            _baseDal = new PulseDAL();
        }


        public void 初始化业务订单号()
        {
            var PulseList = new List<Q_Pulse>();
            var football = new Q_Pulse { Name = "ZQC8", Num = 1, AddTime = DateTime.Now, desc = "足球竞彩订单号", IsReset = 0, UpdateTime = DateTime.Now };
            var dichroicball = new Q_Pulse { Name = "SSQ8", Num = 1, AddTime = DateTime.Now, desc = "双色球订单号", IsReset = 0, UpdateTime = DateTime.Now };
            PulseList.Add(football);
            PulseList.Add(dichroicball);
            _baseDal.BulkInsert(PulseList);
        }

        /// <summary>
        /// 根据业务名称获取订单号
        /// </summary>
        /// <param name="Name">业务名称</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public string GetOrderNoByName(string Name, int userId)
        {
            string dateNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            string userNo = userId.ToString().PadLeft(6, '0');
            var pulseNo = (_baseDal as PulseDAL).PulseNo(Name).ToString().PadLeft(8, '0');
            return $"{Name}{dateNo}{userNo}{pulseNo}";
        }

    }
}
