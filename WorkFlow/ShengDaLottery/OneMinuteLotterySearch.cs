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
    /// 一分菜数据接口
    /// </summary>
    public class OneMinuteLotterySearch
    {

        /// <summary>
        /// 分分彩查询前20条
        /// </summary>
        /// <param name="session_id"></param>
        public static List<ReqFiveMinuteLottery> FiveMinuteQueryByTopTwenty(string session_id)
        {
            var reqfmlResultList = new List<ReqFiveMinuteLottery>();
            try
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("action", "GetLotteryOpen20List");
                param.Add("lottery_code", ((int)LotteryCodeEnum.OneMinuteLottery).ToString());
                param.Add("data_count", "20");
                param.Add("session_id", session_id);
                string data = FiveMinuteLotterySearch.JoinParams(param);
                var reult = HttpMethods.HttpPost(ShengDaUrl.LotteryQuery, data);
                var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
                reqfmlResultList = JsonConvert.DeserializeObject<List<ReqFiveMinuteLottery>>(baseObj.data);
                //foreach (var item in fmlObj)
                //{
                //    var reqfmlResult = new ReqFiveMinuteLotteryResult() { IssueCode = item.issue_no, OpenTime = item.open_time };
                //    var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                //    reqfmlResult.One = int.Parse(list2[0]);
                //    reqfmlResult.Two = int.Parse(list2[1]);
                //    reqfmlResult.Three = int.Parse(list2[2]);
                //    reqfmlResult.Four = int.Parse(list2[3]);
                //    reqfmlResult.Five = int.Parse(list2[4]);
                //    reqfmlResultList.Add(reqfmlResult);
                //}
            }
            catch (Exception e)
            {
                Log.Write(LogLevel.Error, $"报错了，消息为{e.Message}");
            }
            return reqfmlResultList;
        }
    }
}
