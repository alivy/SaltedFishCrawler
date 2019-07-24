using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.FootballGameCrawler
{
    /// <summary>
    /// 半全场平负数据查询
    /// </summary>
    public class HalfCourtNegativeSearch : ISearch
    {
       

        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.HalfCourtNegative;
        }
        public override BaseFootballGame Process()
        {
            var json = ResultRequest();
            ///此处编写实例对面业务逻辑      
            return new HalfCourtNegativeDate();
        }
    }
}
