using System;
using System.Collections.Generic;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Utils.Help.Http;

namespace FishTest
{
    [TestClass]
    public class ShengDaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string date = "action=GetLotteryOpen20List&lottery_code=1004&data_count=20&session_id=dbd298dff709486288df429e42504926";
            var reult = HttpMethods.HttpPost("https://shengdaweb.0451pz.com/Home/Buy", date);
            var baseObj = JsonConvert.DeserializeObject<BaseRes<string>>(reult);
            var fmlObj = JsonConvert.DeserializeObject<List<ReqFiveMinuteLottery>>(baseObj.data);
            var reqfmlResultList = new List<ReqFiveMinuteLotteryResult>();
            foreach (var item in fmlObj)
            {
                var reqfmlResult = new ReqFiveMinuteLotteryResult() { IssueCode = item.issue_no,  OpenTime = item.open_time };
                var list2 = new List<string>(item.lotteryopen_no.Split(new[] { "," }, StringSplitOptions.None));
                reqfmlResult.One = list2[0];
                reqfmlResult.Two = list2[1];
                reqfmlResult.Three = list2[2];
                reqfmlResult.Four = list2[3];
                reqfmlResult.Five = list2[4];
                reqfmlResultList.Add(reqfmlResult);
            }
            

        }
    }
}
