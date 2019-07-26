using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
            WinOrLoseDate winolostdata = new WinOrLoseDate();
            var json = ResultRequest();
            json = json.Substring(0, json.Length - 2).Substring(8);
            JObject object1= JObject.Parse(json);
            string jsonnew=  object1["data"].ToString();
            JObject object2 = JObject.Parse(jsonnew);
            string jsonnew1 = "[";
            foreach (JProperty jProperty in object2.Properties())
            {
                jsonnew1 += jProperty.Value+",";
            }
            jsonnew1=jsonnew1.TrimEnd(',');
            jsonnew1 += "]";
            string status= object1["status"].ToString();
            string jsonend = "{\"data\":" + jsonnew1 + ",\"status\":" + status+"}";
            winolostdata = new JavaScriptSerializer().Deserialize<WinOrLoseDate>(jsonend);
            return winolostdata;
            ///此处编写实例对面业务逻辑         
           // return new WinOrLoseDate();
        }

    }
}
