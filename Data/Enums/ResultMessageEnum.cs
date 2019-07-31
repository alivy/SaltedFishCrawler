using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;


namespace Data.Enums
{
    /// <summary>
    /// 返回消息的枚举
    /// </summary>
    public enum ResultMessageEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Remark("成功")]
        Success = 1,

        /// <summary>
        /// 验证失败
        /// </summary>
        [Remark("验证失败")]
        ValidateError = 2,

        /// <summary>
        /// 错误，已知的错误
        /// </summary>
        [Remark("错误，已知的错误")]
        Error = 3,

        /// <summary>
        /// 错误，写在try catch中的错误
        /// </summary>
        [Remark("错误，写在try catch中的错误")]
        Exception = 4,

        /// <summary>
        /// 权限验证
        /// </summary>
        [Remark("权限验证")]
        AuthorityCheck = 5,

        /// <summary>
        /// 基础权限校验失败
        /// 如：用户不存在，ip不允许等等
        /// </summary>
        [Remark("基础权限校验失败")]
        BaseAuthorityCheckFailed = 6,
    }
}
