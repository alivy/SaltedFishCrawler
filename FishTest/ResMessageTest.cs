using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Data.Enums;
using Data.FootballGameModel;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Data.StaticModel;
using Data.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utils.Help;
using Utils.Help.Http;
using WorkFlow.FootballGameCrawler;

namespace FishTest
{
    /// <summary>
    /// 返回消息测试
    /// </summary>
    [TestClass]
    public class ResMessageTest
    {

        /// <summary>
        /// 使用ResMessage返回消息对象
        /// </summary>
        [TestMethod]
        public void ResultMessageTest()
        {
            var obj = new { Id = 1, Name = "二狗子" };

            var viewModel = ResMessage.CreatMessage(ResultMessageEnum.Success);
            var json = JsonHelper.Serialize(viewModel);


            viewModel = ResMessage.CreatMessage(ResultMessageEnum.Success, "业务处理成功");
            json = JsonHelper.Serialize(viewModel);


            viewModel = ResMessage.CreatMessage(ResultMessageEnum.Success, obj);
            json = JsonHelper.Serialize(viewModel);


            viewModel = ResMessage.CreatMessage(ResultMessageEnum.Success, "业务处理成功", obj);
            json = JsonHelper.Serialize(viewModel);
        }

        [TestMethod]
        public void ResultTest()
        {
            int examExplain = 20190711;
            var result1 = Convert.ToDateTime(examExplain.ToString()).ToString("yyyy-MM-dd HH:mm:ss");


            string date = "action=GetLotteryOpen20List&lottery_code=1004&data_count=20&session_id=dbd298dff709486288df429e42504926";
            var reult = HttpMethods.HttpPost("https://shengdaweb.0451pz.com/Home/Buy", date);
            var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
            var fmlObj = JsonConvert.DeserializeObject<List<ReqFiveMinuteLottery>>(baseObj.data);
            var reqfmlResultList = new List<ReqFiveMinuteLotteryResult>();
            foreach (var item in fmlObj)
            {
                var reqfmlResult = new ReqFiveMinuteLotteryResult() { IssueCode = item.issue_no,  OpenTime = item.open_time };
                var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                //reqfmlResult.One = list2[0];
                //reqfmlResult.Two = list2[1];
                //reqfmlResult.Three = list2[2];
                //reqfmlResult.Four = list2[3];
                //reqfmlResult.Five = list2[4];
                reqfmlResultList.Add(reqfmlResult);
            }

        }
    }
}
