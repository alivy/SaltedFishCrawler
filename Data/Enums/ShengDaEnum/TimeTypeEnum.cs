using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums.ShengDaEnum
{
    /// <summary>
    /// 查询投注记录日期类型枚举
    /// </summary>
    public enum TimeTypeEnum
    {
        /// <summary>
        /// 今天
        /// </summary>
        Today =1,
        /// <summary>
        /// 昨天
        /// </summary>
        Yesterday =2,
        /// <summary>
        /// 近七天
        /// </summary>
        Week =3
    }
}
