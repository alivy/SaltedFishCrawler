using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;

namespace Data.Enums.ShengDaEnum
{
    /// <summary>
    /// 五分彩选中的球位置
    /// </summary>
    public enum FiveMinLotteryBettingNumberEnum
    {
        /// <summary>
        /// 第一位
        /// </summary>
        [Remark("10A0")]
        one = 1,
        [Remark("10B0")]
        two = 2,
        [Remark("10C0")]
        tree = 3,
        [Remark("10D0")]
        four = 4,
        [Remark("10E0")]
        five = 5
    }
}
