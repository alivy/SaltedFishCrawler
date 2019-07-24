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
    /// 总进球数据查询
    /// </summary>
    public class TotalGoalsSearch : ISearch
    {
        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.TotalGoals;
        }


        public override BaseFootballGame Process()
        {
            var json = ResultRequest();
            ///此处编写实例对面业务逻辑      
            return new TotalGoalsDate();
        }
    }
}
