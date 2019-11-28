using BLL;
using Data.Model.DBModel;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils.Help.Http;
using WorkFlow.ShengDaLottery;

namespace WeiCaiConsole
{
    public class TwoDogsJob : IJob
    { 
        public static  string session_id = ConfigurationManager.AppSettings["session_id"];
        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string k = dataMap.GetString("key");//获取参数(可根据传递的类型使用GetInt、GetFloat、GetString.....)
            Console.WriteLine($"成功接收：{k}");
            return Task.Run(() => Process());
        }

        /// <summary>
        /// 主要执行逻辑
        /// </summary>
        public void Process()
        {
           var fiveMinuteLottery =  new FiveMinuteLotteryBLL();
            fiveMinuteLottery.FiveMinuteLotteryDataSync(session_id);
            Console.WriteLine("成功同步五分彩数据。。。。!");
            fiveMinuteLottery.OneMinuteLotteryDataSync(session_id);
            Console.WriteLine("成功同步分分彩数据。。。。!");
            //var football = new FootballMatchBLL();
            //football.SysnWinOrLose();
            //football.SysnTotalGoals();
            //football.SysnMatchScore();
            //football.SysnHalfCourtNegative();
            //FiveMinuteLotteryDataSync();
            Console.WriteLine("正在处理数据。。。。!");
        }

        /// <summary>
        /// 五分彩数据同步
        /// </summary>
        public void FiveMinuteLotteryDataSync()
        {
            try
            {
                var dataStr = DateTime.Now.ToString("yyyyMMdd");
                var FiveMinuteLotteryList = new BaseBLL<FiveMinuteLottery>().LoadEntities(x => x.ID.Contains(dataStr)).ToList();
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



    }
}
