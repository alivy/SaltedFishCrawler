using DAL;
using Data.Enums.ShengDaEnum;
using Data.Model.DBModel;
using Data.Model.FiveMinuteLotteryModel;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Help.Http;
using WorkFlow.ShengDaLottery;

namespace BLL
{
    /// <summary>
    /// 五分彩数据逻辑
    /// </summary>
    public class FiveMinuteLotteryBLL : BaseBLL<FiveMinuteLottery>
    {
        public override void SetDal()
        {
            _baseDal = new FiveMinuteLotteryDal();
        }

        /// <summary>
        /// 查询某天最多大小单双练注数
        /// </summary>
        /// <param name="dateTime"></param>
        public List<FiveMinuteResultAnalysis> MaxSingleDoubleOrSize(bool allDate, DateTime dateTime)
        {
            var dataStr = dateTime.ToString("yyyyMMdd");
            var fiveMinuteLotteryList = _baseDal.LoadEntities(x => allDate ? true : x.ID.Contains(dataStr)).OrderBy(x => x.ID).ToList();
            List<FiveMinuteResultAnalysis> fiveMinuteResultAnalyses = new List<FiveMinuteResultAnalysis>();
            for (int i = 1; i < 6; i++)
            {
                var fiveMinuteResult = FiveMinuteResultAnalysisResult(fiveMinuteLotteryList, i);
                fiveMinuteResultAnalyses.Add(fiveMinuteResult);
            }
            return fiveMinuteResultAnalyses;
        }


        /// <summary>
        /// 五分彩开奖数据分析数据
        /// </summary>
        /// <param name="fiveMinuteLotteryList"></param>
        /// <param name="num"></param>
        /// <returns></returns>

        public FiveMinuteResultAnalysis FiveMinuteResultAnalysisResult(List<FiveMinuteLottery> fiveMinuteLotteryList, int num)
        {
            int singleNum = 1;
            int doubleNum = 1;
            int largeNum = 1;
            int sizeNum = 1;
            //大小穿插数
            int sizeLargeNum = 1;
            //单双穿插数
            int singleDoubleNum = 1;
            var pastFiveMinute = new FiveMinuteLottery();
            var oneFiveMinute = new FiveMinuteResultAnalysis() { DataBits = num };
            foreach (var item in fiveMinuteLotteryList)
            {
                if (pastFiveMinute != null)
                {

                    //当前开奖号
                    var lotteryNum = GetLotteryNumber(num, item);
                    //上一注开奖号
                    var pastlotteryNum = GetLotteryNumber(num, pastFiveMinute);

                    #region 单双数据
                    if (lotteryNum % 2 == 0 && pastlotteryNum % 2 == 0)
                    {
                        doubleNum++;
                        singleDoubleNum = 1;
                        oneFiveMinute.DoubleNum = doubleNum > oneFiveMinute.DoubleNum ? doubleNum : oneFiveMinute.DoubleNum;
                    }
                    else if (lotteryNum % 2 != 0 && pastlotteryNum % 2 != 0)
                    {
                        singleNum++;
                        singleDoubleNum = 1;
                        oneFiveMinute.SingleNum = singleNum > oneFiveMinute.SingleNum ? singleNum : oneFiveMinute.SingleNum;
                    }
                    else
                    {
                        singleDoubleNum++;
                        doubleNum = 1;
                        singleNum = 1;
                        oneFiveMinute.SingleDoubleNum = singleDoubleNum > oneFiveMinute.SingleDoubleNum ? singleDoubleNum : oneFiveMinute.SingleDoubleNum;
                    }
                    #endregion

                    #region 大小数据
                    if (lotteryNum < 5 && pastlotteryNum < 5)
                    {
                        sizeNum++;
                        sizeLargeNum = 1;
                        oneFiveMinute.Size = sizeNum > oneFiveMinute.Size ? sizeNum : oneFiveMinute.Size;
                    }
                    else if (lotteryNum >= 5 && pastlotteryNum >= 5)
                    {
                        largeNum++;
                        sizeLargeNum = 1;
                        oneFiveMinute.Large = largeNum > oneFiveMinute.Large ? largeNum : oneFiveMinute.Large;
                    }
                    else
                    {
                        sizeLargeNum++;
                        sizeNum = 1;
                        largeNum = 1;
                        oneFiveMinute.LargeSizeNum = sizeLargeNum > oneFiveMinute.LargeSizeNum ? sizeLargeNum : oneFiveMinute.LargeSizeNum;
                    }
                    #endregion
                }
                pastFiveMinute = item;
            }


            return oneFiveMinute;
        }

        /// <summary>
        /// 获取开奖球数据位
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <returns></returns>
        private int GetLotteryNumber(int ballPosition, FiveMinuteLottery fiveMinute)
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

        /// <summary>
        /// 五分彩数据同步
        /// </summary>
        public void FiveMinuteLotteryDataSync(string session_id)
        {
            try
            {
                var dataStr = DateTime.Now.ToString("yyyyMMdd");
                var FiveMinuteLotteryList = _baseDal.LoadEntities(x => x.ID.Contains(dataStr)).ToList();
                string date = $"action=GetLotteryOpen20List&lottery_code=1004&data_count=20&session_id={session_id}";
                var reult = HttpMethods.HttpPost(ShengDaUrl.LotteryQuery, date);
                var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
                var fmlObj = JsonConvert.DeserializeObject<List<ReqFiveMinuteLottery>>(baseObj.data);
                var reqfmlResultList = new List<FiveMinuteLottery>();
                foreach (var item in fmlObj)
                {
                    var reqfmlResult = new FiveMinuteLottery() { ID = item.issue_no, OpenTime = item.open_time };
                    var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                    reqfmlResult.One = int.Parse(list2[0]);
                    reqfmlResult.Two = int.Parse(list2[1]);
                    reqfmlResult.Three = int.Parse(list2[2]);
                    reqfmlResult.Four = int.Parse(list2[3]);
                    reqfmlResult.Five = int.Parse(list2[4]);
                    reqfmlResultList.Add(reqfmlResult);
                }
                if (FiveMinuteLotteryList != null & FiveMinuteLotteryList.Count > 0)
                {
                    reqfmlResultList = reqfmlResultList.Where(x => FiveMinuteLotteryList.FirstOrDefault(y => y.ID == x.ID) == null).ToList();
                }
                new BaseBLL<FiveMinuteLottery>().BulkInsert2(reqfmlResultList);
            }
            catch (Exception e)
            {
                Console.WriteLine($"报错了，消息为{e.Message}");
            }
        }

        /// <summary>
        /// 分分彩数据同步
        /// </summary>
        public void OneMinuteLotteryDataSync(string session_id)
        {
            try
            {
                var dataStr = DateTime.Now.ToString("yyyyMMdd");
                var oneMinuteLotteryList = new BaseBLL<OneMinuteLottery>().LoadEntities(x => x.ID.Contains(dataStr)).ToList();
                var fmlObj = OneMinuteLotterySearch.FiveMinuteQueryByTopTwenty(session_id);
                var reqfmlResultList = new List<OneMinuteLottery>();
                foreach (var item in fmlObj)
                {
                    var reqfmlResult = new OneMinuteLottery() { ID = item.issue_no, OpenTime = item.open_time };
                    var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                    reqfmlResult.One = int.Parse(list2[0]);
                    reqfmlResult.Two = int.Parse(list2[1]);
                    reqfmlResult.Three = int.Parse(list2[2]);
                    reqfmlResult.Four = int.Parse(list2[3]);
                    reqfmlResult.Five = int.Parse(list2[4]);
                    reqfmlResultList.Add(reqfmlResult);
                }
                if (oneMinuteLotteryList != null & oneMinuteLotteryList.Count > 0)
                {
                    reqfmlResultList = reqfmlResultList.Where(x => oneMinuteLotteryList.FirstOrDefault(y => y.ID == x.ID) == null).ToList();
                }
                new BaseBLL<OneMinuteLottery>().BulkInsert2(reqfmlResultList);
            }
            catch (Exception e)
            {
                Console.WriteLine($"报错了，消息为{e.Message}");
            }
        }
    }
}
