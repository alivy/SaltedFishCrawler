using Data.Enums;
using Data.FootballGameModel;
using Data.FootballGameModel.MatchScore;
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
    /// 比分数据查询
    /// </summary>
    public class MatchScoreSearch : ISearch
    {
      

        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.Score;
        }

        public override BaseFootballGame Process()
        {
            MatchScoreDate matchScoreData = new MatchScoreDate();
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
            jsonend = jsonend.Replace("\"-1-a\"", "s1");
            jsonend = jsonend.Replace("\"-1-d\"", "s2");
            jsonend = jsonend.Replace("\"-1-h\"", "s3");
            jsonend = jsonend.Replace("\"0000\"", "s4");
            jsonend = jsonend.Replace("\"0001\"", "s5");
            jsonend = jsonend.Replace("\"0002\"", "s6");
            jsonend = jsonend.Replace("\"0003\"", "s7");
            jsonend = jsonend.Replace("\"0004\"", "s8");
            jsonend = jsonend.Replace("\"0005\"", "s9");
            jsonend = jsonend.Replace("\"0100\"", "s10");
            jsonend = jsonend.Replace("\"0101\"", "s11");
            jsonend = jsonend.Replace("\"0102\"", "s12");
            jsonend = jsonend.Replace("\"0103\"", "s13");
            jsonend = jsonend.Replace("\"0104\"", "s14");
            jsonend = jsonend.Replace("\"0105\"", "s15");
            jsonend = jsonend.Replace("\"0200\"", "s16");
            jsonend = jsonend.Replace("\"0201\"", "s17");
            jsonend = jsonend.Replace("\"0202\"", "s18");
            jsonend = jsonend.Replace("\"0203\"", "s19");
            jsonend = jsonend.Replace("\"0204\"", "s20");
            jsonend = jsonend.Replace("\"0205\"", "s21");
            jsonend = jsonend.Replace("\"0300\"", "s22");
            jsonend = jsonend.Replace("\"0301\"", "s23");
            jsonend = jsonend.Replace("\"0302\"", "s24");
            jsonend = jsonend.Replace("\"0303\"", "s25");
            jsonend = jsonend.Replace("\"0400\"", "s26");
            jsonend = jsonend.Replace("\"0401\"", "s27");
            jsonend = jsonend.Replace("\"0402\"", "s28");
            jsonend = jsonend.Replace("\"0500\"", "s29");
            jsonend = jsonend.Replace("\"0501\"", "s30");
            jsonend = jsonend.Replace("\"0502\"", "s31");

            matchScoreData = new JavaScriptSerializer().Deserialize<MatchScoreDate>(jsonend);
            return matchScoreData;
            ///此处编写实例对面业务逻辑      
            //return new MatchScoreDate();
        }
    }
}
