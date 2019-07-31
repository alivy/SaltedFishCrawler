using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Data.Enums;
using Data.FootballGameModel;
using Data.StaticModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Utils.Help.Http;
using WorkFlow.FootballGameCrawler;

namespace FishTest
{
    /// <summary>
    /// 足彩测试
    /// </summary>
    [TestClass]
    public class JsonTransTest
    {
        [TestMethod]
        public void jsonTest()
        {
            string strJson = "{\"ttg\":{ \"s0\":\"11.50\",\"s1\":\"4.80\",\"s2\":\"3.40\",\"s3\":\"3.35\",\"s4\":\"4.85\", \"s5\":\"8.50\", \"s6\":\"16.00\", \"s7\":\"25.00\" }}";
            JObject jsonObj = JObject.Parse(strJson);
            var strResult = GetNestJsonValue(jsonObj.Children());

        }


        /// <summary>
        /// 迭代获取eky对应的值
        /// </summary>
        /// <param name="jToken"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<JsonResult> GetNestJsonValue(JEnumerable<JToken> jToken)
        {
            IEnumerator enumerator = jToken.GetEnumerator();
            List<JsonResult> jsonResults = new List<JsonResult>();
            while (enumerator.MoveNext())
            {
                JToken jc = (JToken)enumerator.Current;
                var jValue = (JObject)((JProperty)jc).Value;
                foreach (JProperty jProperty in jValue.Properties())
                {
                    string name = jProperty.Name;
                    var jPValue = jProperty.Value.ToString();
                    jsonResults.Add(new JsonResult()
                    {
                        Name = name,
                        Vaule = jPValue
                    });
                }
            }
            return jsonResults;
        }
    }

    public class JsonResult
    {
        public string Name { get; set; }
        public string Vaule { get; set; }
    }
}
