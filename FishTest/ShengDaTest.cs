using System;
using System.Collections.Generic;
using BLL;
using Data.Model.ShengDa.Requset;
using Data.Model.ShengDa.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Utils.Help.Http;
using WorkFlow.ShengDaLottery;

namespace FishTest
{
    [TestClass]
    public class ShengDaTest
    {
        [TestMethod]
        public void FiveMinuteOrder()
        {
            //  FiveMinuteLotterySearch.FiveMinuteOrder();
        }

        [TestMethod]
        public void MaxSingleDoubleOrSizeTest()
        {
            var date = DateTime.Now.AddDays(-1);
            FiveMinuteLotteryBLL lotteryBLL = new FiveMinuteLotteryBLL();
            var result = lotteryBLL.MaxSingleDoubleOrSize(true, date);
        }
    }
}
