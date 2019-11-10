using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.FiveMinuteLotteryModel
{

    /// <summary>
    /// 五分彩开奖结果分析
    /// </summary>
    public class FiveMinuteResultAnalysis
    {


        /// <summary>
        /// 开奖球数据位 <see cref="Enums.ShengDaEnum.FiveMinLotteryBettingNumberEnum"/>
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 开单连续数
        /// </summary>
        public int SingleNum { get; set; }
        /// <summary>
        /// 开双连续数
        /// </summary>
        public int DoubleNum { get; set; }
        /// <summary>
        /// 开大连续数
        /// </summary>
        public int Large { get; set; }

        /// <summary>
        /// 开小连续数
        /// </summary>
        public int Size { get; set; }


        /// <summary>
        /// 单双穿插连续数
        /// </summary>
        public int SingleDoubleNum { get; set; }

        /// <summary>
        /// 大小穿插连续数
        /// </summary>
        public int LargeSizeNum { get; set; }
    }
}
