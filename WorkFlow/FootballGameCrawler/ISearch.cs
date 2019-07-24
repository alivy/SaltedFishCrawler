using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Help.Http;

namespace WorkFlow.FootballGameCrawler
{

    public abstract class ISearch
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <returns></returns>
        public abstract FootballGameTypeEnum FootballGameType();

        /// <summary>
        /// 主要业务逻辑
        /// </summary>
        /// <param name="gameTypeEnum"></param>
        /// <returns></returns>
        public abstract BaseFootballGame Process();
        

        /// <summary>
        /// 获取数据请求结果
        /// </summary>
        /// <param name="gameTypeEnum"></param>
        protected virtual string ResultRequest()
        {
            var footballGameType = FootballGameType();
            string timeStamp = GetTimeStamp();
            string url = string.Format(CrawlerUrl.FootballDataDir[footballGameType], timeStamp);
            var json = Request(url);
            return json;
        }

        /// <summary>
        /// 通过接口获取数据
        /// </summary>
        /// <returns></returns>
        protected static string Request(string url)
        {
            Hashtable headht = new Hashtable();
            headht.Add("X-WAF-UUID", "271e7cdd-14b7-4e1b-a8f0-dfe7a3e870ba");
            headht.Add("X-Cache", "MISS");
            headht.Add("Vary", "Accept-Encoding");
            headht.Add("X-Powered-By", "PHP/5.6.38");
            headht.Add("Server", "nginx");
            var result = HttpMethods.HttpGet(url);
            return result;
        }

        /// <summary> 
        /// 获取时间戳 
        /// </summary> 
        /// <returns></returns> 
        protected static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
