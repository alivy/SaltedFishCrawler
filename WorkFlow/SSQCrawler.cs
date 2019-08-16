using Data.Model.SSQModel;
using Data.StaticModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Help;
using Utils.Help.Http;

namespace WorkFlow
{
    public class SSQCrawler
    {
        /// <summary>
        /// 获取开彩网双色球信息
        /// 开彩网API开放平台(免费接口)的开奖结果调用不需要进行任何注册或申请即可直接调用。
        /// 开彩网API开放平台(免费接口)的开奖结果发布有2分钟至6分钟的随机延迟。
        /// 开彩网API开放平台(免费接口)在调用过程中请注意控制每种彩票访问间隔不小于10秒。
        /// </summary>
        public CrawlSSQInfo KcAPI()
        {
            var ssqJson = HttpMethods.HttpGet(CrawlerUrl.ssq);
            var ssqInfo= JsonHelper.Deserialize<CrawlSSQInfo>(ssqJson);
            return ssqInfo;
        }
    }
}
