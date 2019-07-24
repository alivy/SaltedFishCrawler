using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Utils.Help.Http;

namespace WorkFlow.FootballGameCrawler
{
    /// <summary>
    /// 胜平负数据查询
    /// </summary>
    public class WinOrLoseSearch : ISearch
    {

        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.WinOrLose;
        }

        public override BaseFootballGame Process()
        {
            var json = ResultRequest();
            ///此处编写实例对面业务逻辑         
            return new WinOrLoseDate();
        }

    }
}
