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

        public void jsonTest()
        {
            string json = "ttg\":{ \"s0\":\"11.50\",\"s1\":\"4.80\",\"s2\":\"3.40\",\"s3\":\"3.35\",\"s4\":\"4.85\", \"s5\":\"8.50\", \"s6\":\"16.00\", \"s7\":\"25.00\" }";


        }
    }
}
