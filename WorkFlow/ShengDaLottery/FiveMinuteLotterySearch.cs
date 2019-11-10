using Data.Enums.ShengDaEnum;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<ReqFiveMinuteLotteryResult> FiveMinuteQuery(string session_id)
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
        public static void FiveMinuteOrderQuery(string session_id)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("action", "GetBettingOrder");
            param.Add("lottery_code", ((int)LotteryCodeEnum.FiveMinuteLottery).ToString());
            param.Add("time_type", ((int)TimeTypeEnum.Today).ToString()); //1今天 2昨天 3近七天
            param.Add("open_state", "-3");
            param.Add("page_index", "1");
            param.Add("session_id", session_id);
            string date = JoinParams(param);
            var reult = HttpMethods.HttpPost(ShengDaUrl.BettingResultQuery, date);
            var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
            var fmlObj = JsonConvert.DeserializeObject<BettingResultResponse>(baseObj.data);
        }

        /// <summary>
        /// 下单接口
        /// </summary>
        /// <param name="session_id"></param>
        public static void FiveMinuteOrder(PlaceOrderRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var reult = HttpMethods.HttpPost(ShengDaUrl.BettingResultQuery, json);

        }




        private static string JoinParams(Dictionary<string, string> param)
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
