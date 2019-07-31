using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var viewModel = ViewModel.ResMessage.CreatMessage(ResultMessageEnum.Success);
            var json = JsonHelper.Serialize(viewModel);


            viewModel = ViewModel.ResMessage.CreatMessage(ResultMessageEnum.Success, "业务处理成功");
            json = JsonHelper.Serialize(viewModel);


            viewModel = ViewModel.ResMessage.CreatMessage(ResultMessageEnum.Success, obj);
            json = JsonHelper.Serialize(viewModel);


            viewModel = ViewModel.ResMessage.CreatMessage(ResultMessageEnum.Success, "业务处理成功", obj);
            json = JsonHelper.Serialize(viewModel);
        }

      
    }
}
