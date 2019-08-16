using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.SSQModel
{
    /// <summary>
    /// 爬取双色球接口信息
    /// </summary>
    public class CrawlSSQInfo
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int row { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<SSQLotteryInfo> data { get; set; }
    }

    /// <summary>
    /// 双色球开奖信息
    /// </summary>
    public class SSQLotteryInfo
    {
        /// <summary>
        /// 期数
        /// </summary>
        public string expect { get; set; }

        /// <summary>
        /// 开奖号码
        /// </summary>
        public string opencode { get; set; }
        /// <summary>
        /// 开奖时间
        /// </summary>
        public DateTime opentime { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public int opentimestamp { get; set; }
    }
}
