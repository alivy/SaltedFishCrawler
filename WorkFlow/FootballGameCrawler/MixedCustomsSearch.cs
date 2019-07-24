using Data.Enum;
using Data.FootballGameModel;
using Data.StaticModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Help.Http;

namespace WorkFlow.FootballGameCrawler
{
    /// <summary>
    /// 混合过关数据查询
    /// </summary>
    public class MixedCustomsSearch : ISearch
    {


        public override FootballGameTypeEnum FootballGameType()
        {
            return FootballGameTypeEnum.MixedCustoms;
        }

        /// <summary>
        /// 这里只能使用爬虫获取数据,此数据暂时不取
        /// </summary>
        /// <returns></returns>
        protected override string ResultRequest()
        {
            HtmlWeb webClient = new HtmlWeb();
            var url = CrawlerUrl.FootballDir[FootballGameType()];
            var html = HttpHelper.DownloadHtml(url, Encoding.UTF8);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);//加载html
            //HtmlDocument doc = webClient.Load(url);
            string pageNumberPath = @".//div[@class='portlet']";
            HtmlNodeCollection meat_property_List = doc.DocumentNode.SelectNodes(pageNumberPath);
            if (meat_property_List != null)
            {
                foreach (HtmlNode meat_property in meat_property_List)
                {
                    var propertyObj = meat_property.Attributes["property"]?.Value;
                    if (propertyObj != null)
                    {
                        HtmlAttribute property_att = meat_property.Attributes["property"];
                        HtmlAttribute content_att = meat_property.Attributes["content"];
                        Console.WriteLine(string.Format("{0}\t:\t{1}", property_att.Value, content_att.Value));
                    }
                }
            }

            return "";
        }

        public override BaseFootballGame Process()
        {
            var json = ResultRequest();
            ///此处编写实例对面业务逻辑      
            return new MixedCustomsDate();
        }
    }
}
