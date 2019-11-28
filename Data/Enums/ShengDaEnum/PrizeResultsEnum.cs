using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;

namespace Data.Enums.ShengDaEnum
{
    /// <summary>
    /// 开奖结果枚举
    /// </summary>
    public enum PrizeResultsEnum
    {
        [Remark("单")]
        single = 1,
        [Remark("双")]
        doubles = 2,
        [Remark("大")]
        large = 3,
        [Remark("小")]
        size = 4
    }
}
