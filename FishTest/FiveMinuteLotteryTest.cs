using System;
using System.Collections.Generic;
using Data.Enums.ShengDaEnum;
using Data.Model.ShengDa.Requset;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.CustomAttribute;
using WorkFlow.ShengDaLottery;
using System.Linq;
using Data.Model.DBModel;
using Utils.Cache;

namespace FishTest
{
    [TestClass]
    public class FiveMinuteLotteryTest
    {
        /// <summary>
        /// 五分彩下单数据查询接口测试
        /// </summary>
        [TestMethod]
        public void FiveMinuteOrderQuery()
        {
            var session_id = "0b735f590aa3471a893481596d62c682";
            FiveMinuteLotterySearch.FiveMinuteOrderQuery(session_id);
        }

        /// <summary>
        /// 五分彩下单接口测试
        /// </summary>

        [TestMethod]
        public void FiveMinuteOrderTest()
        {
            PlaceOrderRequest request = new PlaceOrderRequest() { BettingData = new Datas() { BettingData = new List<BettingDataInfo>() } };
            List<BettingDataInfo> bettings = new List<BettingDataInfo>()
            {
                new  BettingDataInfo
                {
                    lottery_code ="1004",
                    play_detail_code =FiveMinLotteryBettingNumberEnum.one.GetRemark(),
                    issuseNo ="20191125191",
                    betting_number="单",
                    betting_money =1,
                    betting_count =1,
                    client_type =1
                }
            };
            request.BettingData.BettingData = bettings;
            request.session_id = "0b735f590aa3471a893481596d62c682";
            var result = FiveMinuteLotterySearch.FiveMinuteOrder(request);
            Assert.AreEqual(result.Code, 1);
        }


        /// <summary>
        /// 五分彩自动投注
        /// </summary>
        [TestMethod]
        public void FiveMinuteAutomaticBetting_Test()
        {
            var session_id = "0b735f590aa3471a893481596d62c682";
            FiveMinuteLotterySearch.FiveMinuteAutomaticBetting(session_id);
        }

        /// <summary>
        /// 五分彩自动投注
        /// </summary>
        [TestMethod]
        public void FiveMinuteAutomaticBettingTest()
        {
            int num = 1; //球号
            var session_id = "520ac16ff76a4887be54fca54775f34c";
            int critical = 5; //表示连续多少注不中起投自动下注临界值
            int maxCritical = 12;//最大连续不中投注期数
            var fiveMinuteQuery = FiveMinuteLotterySearch.FiveMinuteQuery(session_id);
            if (fiveMinuteQuery.Count > 0)
            {
                int singleNum = 1; bool singleEnd = false;
                int doubleNum = 1; bool doubleEnd = false;
                int largeNum = 1; bool largeEnd = false;
                int sizeNum = 1; bool sizeEnd = false;
                fiveMinuteQuery = fiveMinuteQuery.OrderBy(x => x.IssueCode).ToList();
                ReqFiveMinuteLotteryResult pastFiveMinute = null;
                foreach (var fiveMinute in fiveMinuteQuery)
                {
                    if (pastFiveMinute == null)
                    {
                        pastFiveMinute = fiveMinute;
                        continue;
                    }
                    var lotteryNum = GetLotteryNumber(num, fiveMinute);//当前开奖号
                    var pastlotteryNum = GetLotteryNumber(num, pastFiveMinute);  //上一注开奖号
                    if (lotteryNum % 2 == 0 && pastlotteryNum % 2 == 0) //判断都为双
                    {
                        if (doubleEnd == false)
                            doubleNum++;
                        singleEnd = true;
                    }
                    else if (lotteryNum % 2 == 1 && pastlotteryNum % 2 == 1) //判断都为单
                    {
                        if (singleEnd == false)
                            singleNum++;
                        doubleEnd = true;
                    }
                    else
                    {
                        singleEnd = true;
                        doubleEnd = true;
                    }

                    #region 连续大小
                    if (lotteryNum < 5 && pastlotteryNum < 5) //判断都为小
                    {
                        if (sizeEnd == false)
                            sizeNum++;
                        sizeEnd = true;
                    }

                    else if (lotteryNum > 4 && pastlotteryNum > 4) //判断都为大
                    {
                        if (largeEnd == false)
                            largeNum++;
                        largeEnd = true;
                    }
                    else
                    {
                        largeEnd = true;
                        sizeEnd = true;
                    }
                    #endregion
                    if (singleEnd && doubleEnd && largeEnd && sizeEnd)
                        break;
                    pastFiveMinute = fiveMinute;
                }
                if (singleNum > critical)
                {
                    var doubleThrowkey = singleNum >= maxCritical ? singleNum - critical : singleNum - critical;
                    var bettingMoney = OneDoubleThrow[doubleThrowkey];
                    if (singleNum >= maxCritical)
                        bettingMoney = bettingMoney * 5;
                    var bettingNumber = PrizeResultsEnum.doubles.GetRemark();
                    var issuseNo = string.Empty;
                    var issueCode = fiveMinuteQuery[0].IssueCode;
                    if (issueCode.Contains("288"))
                    {
                        int.TryParse(issueCode.Substring(0, issueCode.LastIndexOf("288")), out int code);
                        issuseNo = $"{code + 1}001";
                    }
                    else
                    {
                        int.TryParse(issueCode, out int code);
                        issuseNo = (code + 1).ToString();
                    }
                    var order = FiveMinuteLotterySearch.FiveMinuteOrderQuery(session_id);
                    if (order.sourse.Count > 0)
                    {
                        var orderSourse = order.sourse.FirstOrDefault(x => x.issue_no.Equals(issuseNo));
                        if (orderSourse == null)
                        {
                            List<BettingDataInfo> bettings = new List<BettingDataInfo>()
                            {
                                new BettingDataInfo
                                {
                                    lottery_code = "1004",
                                    play_detail_code = ((FiveMinLotteryBettingNumberEnum)num).GetRemark(),
                                    issuseNo = issuseNo,
                                    betting_number = bettingNumber,
                                    betting_money = bettingMoney,
                                    betting_count = 1,
                                    client_type = 1
                                }
                             };
                            PlaceOrderRequest request = new PlaceOrderRequest() { BettingData = new Datas() { BettingData = bettings }, session_id = session_id };
                            var result = FiveMinuteLotterySearch.FiveMinuteOrder(request);
                        }
                    }
                }
            }
        }




        /// <summary>
        /// 倍投方案一
        /// </summary>
        public Dictionary<int, int> OneDoubleThrow = new Dictionary<int, int>()
        {
            {1,1},{2,2},{3,4},{4,8},{5,16},{6,33},{7,68},{8,136}
        };


        /// <summary>
        /// 倍投方案二
        /// </summary>
        public Dictionary<int, int> TwoDoubleThrow = new Dictionary<int, int>()
        {
           {1,1},{2,3},{3,7},{4,14},{5,30},{6,64},{7,130},{8,270}
        };




        /// <summary>
        /// 获取开奖球数据位
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <returns></returns>
        private int GetLotteryNumber(int ballPosition, ReqFiveMinuteLotteryResult fiveMinute)
        {
            var num = 0;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.one)
                num = fiveMinute.One;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.two)
                num = fiveMinute.Two;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.tree)
                num = fiveMinute.Three;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.four)
                num = fiveMinute.Four;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.five)
                num = fiveMinute.Five;
            return num;
        }
    }
}
