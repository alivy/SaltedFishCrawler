using System;
using System.Text;
using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Help.Http;
using WorkFlow.FootballGameCrawler;

namespace FishTest
{
    /// <summary>
    /// 足彩测试
    /// </summary>
    [TestClass]
    public class FootballGameTest
    {

        /// <summary>
        /// 查询
        /// </summary>
        [TestMethod]
        public void SearchTest()
        {
            ISearch search = new WinOrLoseSearch();
            search.Process();

            search = new TotalGoalsSearch();
            search.Process();

            search = new MatchScoreSearch();
            search.Process();

            search = new HalfCourtNegativeSearch();
            search.Process();
            
        }
    }
}
