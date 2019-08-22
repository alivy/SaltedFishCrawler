using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;

namespace Data.Enums.FootballGameEnum
{
    /// <summary>
    /// 胜平负枚举
    /// </summary>
    public enum WinOrLoseEnum
    {
        /// <summary>
        /// 胜
        /// </summary>
        [Remark("h")]
        Win = 1,
        /// <summary>
        /// 平
        /// </summary>
        [Remark("d")]
        Flat = 2,
        /// <summary>
        /// 负
        /// </summary>
        [Remark("a")]
        Lose = 3,
    }
}
