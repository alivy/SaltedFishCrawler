using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    /// <summary>
    /// 竞彩足球玩法类型
    /// </summary>
    public enum FootballGameTypeEnum
    {
        /// <summary>
        /// 胜平负
        /// </summary>
        WinOrLose = 1,
        /// <summary>
        /// 让球胜平负
        /// </summary>
        LetBallWinOrLose = 2,
        /// <summary>
        /// 比分
        /// </summary>
        Score = 3,
        /// <summary>
        /// 总进球数
        /// </summary>
        TotalGoals = 4,
        /// <summary>
        /// 半全场平负
        /// </summary>
        HalfCourtNegative = 5,
        /// <summary>
        /// 混合过关
        /// </summary>
        MixedCustoms  = 6
    }
}
