using Data.Enums.ShengDaEnum;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;
using Utils.Help;
using Utils.Help.Http;

namespace WorkFlow.ShengDaLottery
{
    /// <summary>
    /// 五分彩接口
    /// </summary>
    public class FiveMinuteLotterySearch
    {
        private const char PARAM_SIGN = '&';
        /// <summary>
        /// 五分彩查询接口
        /// </summary>
        /// <param name="session_id"></param>
        public static List<ReqFiveMinuteLotteryResult> FiveMinuteQuery(string session_id)
        {
            var reqfmlResultList = new List<ReqFiveMinuteLotteryResult>();
            try
            {
                string date = $"action=GetLotteryOpen20List&lottery_code=1004&data_count=20&session_id={session_id}";
                var reult = HttpMethods.HttpPost(ShengDaUrl.LotteryQuery, date);
                var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
                var fmlObj = JsonConvert.DeserializeObject<List<ReqFiveMinuteLottery>>(baseObj.data);

                foreach (var item in fmlObj)
                {
                    var reqfmlResult = new ReqFiveMinuteLotteryResult() { IssueCode = item.issue_no, OpenTime = item.open_time };
                    var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                    reqfmlResult.One = int.Parse(list2[0]);
                    reqfmlResult.Two = int.Parse(list2[1]);
                    reqfmlResult.Three = int.Parse(list2[2]);
                    reqfmlResult.Four = int.Parse(list2[3]);
                    reqfmlResult.Five = int.Parse(list2[4]);
                    reqfmlResultList.Add(reqfmlResult);
                }
            }
            catch (Exception e)
            {
                Log.Write(LogLevel.Error, $"报错了，消息为{e.Message}");
            }
            return reqfmlResultList;
        }


        /// <summary>
        /// 五分彩下单数据查询接口
        /// </summary>
        /// <param name="session_id"></param>
        public static BettingResultResponse FiveMinuteOrderQuery(string session_id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("action", "GetBettingOrder");
            param.Add("lottery_code", ((int)LotteryCodeEnum.FiveMinuteLottery).ToString());
            param.Add("time_type", ((int)TimeTypeEnum.Today).ToString());
            param.Add("open_state", "-3");
            param.Add("page_index", "1");
            param.Add("session_id", session_id);
            string date = JoinParams(param);
            var reult = HttpMethods.HttpPost(ShengDaUrl.BettingResultQuery, date);
            var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
            var fmlObj = JsonConvert.DeserializeObject<BettingResultResponse>(baseObj.data);
            return fmlObj;
        }

        /// <summary>
        /// 下单接口
        /// </summary>
        /// <param name="session_id"></param>
        public static BaseRes<string> FiveMinuteOrder(PlaceOrderRequest request)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string bettingData = JsonConvert.SerializeObject(request.BettingData);
            param.Add("data", bettingData);
            param.Add("session_id", request.session_id);
            string json = JoinParams(param);
            var reult = HttpMethods.HttpPost(ShengDaUrl.AddBetting, json);
            var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
            return baseObj;
        }

        /// <summary>
        /// 自动下注
        /// </summary>
        /// <param name="session_id"></param>
        public static void FiveMinuteAutomaticBetting(string session_id)
        {
            //var tasks = new List<Task>();
            //for (int i = 1; i < 6; i++)
            //{
            //    Task.Run(() => FiveMinuteAutomaticBettingByballNum(session_id, i));
            //}
            //Task.WaitAll(tasks.ToArray());
            for (int i = 1; i < 6; i++)
            {
                FiveMinuteAutomaticBettingByballNum(session_id, 1);
            }
            Console.WriteLine($"自动投注完成");
        }


        /// <summary>
        /// 五分彩自动投注
        /// 此方式是用于控制5-11期间开彩方案，最大连续投注7期
        /// </summary>
        /// <param name="session_id"></param>
        /// <param name="ballNum">球号</param>
        /// <returns></returns>
        public static void FiveMinuteAutomaticBettingByballNum(string session_id, int ballNum)
        {

            var fiveMinuteQuery = FiveMinuteQuery(session_id);
            if (fiveMinuteQuery == null || fiveMinuteQuery.Count == 0)
                return;
            int singleNum = 1; bool singleEnd = false;
            int doubleNum = 1; bool doubleEnd = false;
            int largeNum = 1; bool largeEnd = false;
            int sizeNum = 1; bool sizeEnd = false;
            fiveMinuteQuery = fiveMinuteQuery.OrderByDescending(x => x.IssueCode).ToList();
            var issueCode = fiveMinuteQuery[0].IssueCode; //最近一次开奖号
            var issuseNo = GetNextIssuseNoByIssueCode(issueCode);
            ReqFiveMinuteLotteryResult pastFiveMinute = null;
            foreach (var fiveMinute in fiveMinuteQuery)
            {
                if (pastFiveMinute == null)
                {
                    pastFiveMinute = fiveMinute;
                    continue;
                }
                var lotteryNum = GetLotteryNumber(ballNum, fiveMinute);//当前开奖号
                var pastlotteryNum = GetLotteryNumber(ballNum, pastFiveMinute);  //上一注开奖号
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
            var tasks = new List<Task>();
            tasks.Add(Task.Run(() => AutomaticBetting(singleNum, issuseNo, ballNum, session_id, PrizeResultsEnum.single)));
            tasks.Add(Task.Run(() => AutomaticBetting(doubleNum, issuseNo, ballNum, session_id, PrizeResultsEnum.doubles)));
            tasks.Add(Task.Run(() => AutomaticBetting(largeNum, issuseNo, ballNum, session_id, PrizeResultsEnum.large)));
            tasks.Add(Task.Run(() => AutomaticBetting(sizeNum, issuseNo, ballNum, session_id, PrizeResultsEnum.size)));
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"第{ballNum}自动投注完成");
        }

        /// <summary>
        /// 下注
        /// </summary>
        /// <param name="singleNum"></param>
        /// <param name="issuseNo"></param>
        /// <param name="num"></param>
        /// <param name="session_id"></param>
        public static void AutomaticBetting(int lotteryCount, string issuseNo, int ballNum, string session_id, PrizeResultsEnum prizeResult)
        {
            int critical = 5; //表示连续多少注不中起投自动下注临界值
            int maxCritical = 12;//最大连续不中投注期数
            if (lotteryCount > critical)
            {
                var doubleThrowkey = lotteryCount >= maxCritical ? lotteryCount - maxCritical + 1 : lotteryCount - critical;
                var bettingMoney = OneDoubleThrow[doubleThrowkey];
                if (lotteryCount >= maxCritical)
                    bettingMoney = bettingMoney * 5;
                var bettingNumber = BettingNumber(prizeResult);
                var order = FiveMinuteOrderQuery(session_id);
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
                                    play_detail_code = ((FiveMinLotteryBettingNumberEnum)ballNum).GetRemark(),
                                    issuseNo = issuseNo,
                                    betting_number = bettingNumber,
                                    betting_money = bettingMoney,
                                    betting_count = 1,
                                    client_type = 1
                                }
                             };
                        PlaceOrderRequest request = new PlaceOrderRequest() { BettingData = new Datas() { BettingData = bettings }, session_id = session_id };
                        var result = FiveMinuteOrder(request);
                    }
                }
            }

        }

        /// <summary>
        /// 获取投注号码
        /// </summary>
        /// <param name="prizeResult"></param>
        /// <returns></returns>
        private static string BettingNumber(PrizeResultsEnum prizeResult)
        {
            if (prizeResult == PrizeResultsEnum.doubles)
                return PrizeResultsEnum.single.GetRemark();
            if (prizeResult == PrizeResultsEnum.single)
                return PrizeResultsEnum.doubles.GetRemark();
            if (prizeResult == PrizeResultsEnum.large)
                return PrizeResultsEnum.size.GetRemark();
            if (prizeResult == PrizeResultsEnum.size)
                return PrizeResultsEnum.large.GetRemark();
            return string.Empty;
        }


        /// <summary>
        /// 根据本次号码获取下一期投注编号
        /// </summary>
        /// <param name="issueCode"></param>
        /// <returns></returns>
        public static string GetNextIssuseNoByIssueCode(string issueCode)
        {
            var issuseNo = string.Empty;
            int.TryParse(issueCode.Substring(0, 8), out int date);
            if (issueCode.Contains("288"))
            {
                issuseNo = $"{date + 1}001";
            }
            else
            {
                int.TryParse(issueCode.Substring(8), out int code);
                issuseNo = $"{date}{code + 1}";
            }
            return issuseNo;
        }

        /// <summary>
        /// 倍投方案一
        /// </summary>
        public static Dictionary<int, int> OneDoubleThrow = new Dictionary<int, int>()
        {
            {1,1},{2,2},{3,4},{4,8},{5,16},{6,33},{7,68},{8,136}
        };


        /// <summary>
        /// 倍投方案二
        /// </summary>
        public static Dictionary<int, int> TwoDoubleThrow = new Dictionary<int, int>()
        {
           {1,1},{2,3},{3,7},{4,14},{5,30},{6,64},{7,130},{8,270}
        };




        /// <summary>
        /// 获取开奖球数据位
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <returns></returns>
        public  static int GetLotteryNumber(int ballPosition, ReqFiveMinuteLotteryResult fiveMinute)
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

        public  static string JoinParams(Dictionary<string, string> param)
        {
            StringBuilder data = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                string lastKey = param.Keys.Last();
                foreach (string key in param.Keys)
                {
                    string value = param[key];
                    data.AppendFormat("{0}={1}", key, value);
                    if (key != lastKey)
                        data.Append(PARAM_SIGN);
                }
            }
            return data.ToString();
        }
    }
}
