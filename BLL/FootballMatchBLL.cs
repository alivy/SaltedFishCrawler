using Data.FootballGameModel;
using Data.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public  class FootballMatchBLL: BaseBLL<tblFootballMatch>
    {
        public override void SetDal()
        {
            _baseDal = new FootballMatchDal();
        }
        /// <summary>
        /// 根据赛事id获取赛事详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tblFootballMatch GetMatchInfo(string id)
        {
            return (_baseDal as FootballMatchDal).GetMatchInfo(id);
        }
    }
}
