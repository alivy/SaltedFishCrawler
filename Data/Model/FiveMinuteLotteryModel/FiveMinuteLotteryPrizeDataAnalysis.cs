using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.FiveMinuteLotteryModel
{

    /// <summary>
    /// 五分彩开奖数据分析
    /// </summary>
    public class FiveMinuteLotteryPrizeDataAnalysis
    {


        /// <summary>
        /// 开奖球数据位 <see cref="Enums.ShengDaEnum.FiveMinLotteryBettingNumberEnum"/>
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 最大开单连续数
        /// </summary>
        public int MaxSingleNum { get; set; }
        /// <summary>
        /// 最大开双连续数
        /// </summary>
        public int MaxDoubleNum { get; set; }
        /// <summary>
        /// 最大开大连续数
        /// </summary>
        public int MaxLarge { get; set; }

        /// <summary>
        /// 最大开小连续数
        /// </summary>
        public int MaxSize { get; set; }


        /// <summary>
        /// 最大单双穿插连续数
        /// </summary>
        public int MaxSingleDoubleNum { get; set; }

        /// <summary>
        /// 最大大小穿插连续数
        /// </summary>
        public int MaxLargeSizeNum { get; set; }
    }
}
