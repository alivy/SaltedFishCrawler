using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WorkFlow.FootballGameCrawler
{
    /// <summary>
    /// 总进球数据查询
    /// </summary>
    public class TotalGoalsSearch : ISearch
    {
        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.TotalGoals;
        }


        public override BaseFootballGame Process()
        {
            TotalGoalsDate totalGoalsDate = new TotalGoalsDate();
            var json = ResultRequest();
            json = json.Substring(0, json.Length - 2).Substring(8);
            JObject object1 = JObject.Parse(json);
            string jsonnew = object1["data"].ToString();
            JObject object2 = JObject.Parse(jsonnew);
            string jsonnew1 = "[";
            foreach (JProperty jProperty in object2.Properties())
            {
                jsonnew1 += jProperty.Value + ",";
            }
            jsonnew1 = jsonnew1.TrimEnd(',');
            jsonnew1 += "]";
            string status = object1["status"].ToString();
            string jsonend = "{\"data\":" + jsonnew1 + ",\"status\":" + status + "}";
            totalGoalsDate = new JavaScriptSerializer().Deserialize<TotalGoalsDate>(jsonend);
            return totalGoalsDate;
            ///此处编写实例对面业务逻辑      
            return new TotalGoalsDate();
        }
    }
}
