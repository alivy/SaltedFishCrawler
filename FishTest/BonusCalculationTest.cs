using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FishTest
{
    /// <summary>
    /// 奖金计算
    /// </summary>
    [TestClass]
    public class BonusCalculationTest
    {
        /// <summary>
        /// 计算串关理论最高奖金
        /// </summary>
        [TestMethod]
        public void SupremeTheoreticalBonusTest()
        {
            var result = new List<Betting>()
            {
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2.1}
            };
        }
    }

    public class Betting
    {
        /// <summary>
        /// 赛事Id 
        /// </summary>
        public int MatchId { get; set; }
        /// <summary>
        /// 玩法Id  0让球胜平负  1胜平负
        /// </summary>
        public int PlayId { get; set; }

        /// <summary>
        /// 投注Id 0胜 1平 2负
        /// </summary>
        public int BettingId { get; set; }

        /// <summary>
        /// 赔率
        /// </summary>
        public double Odds { get; set; }
    }
}
