namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 用户表
    /// </summary>
    [Table("UserInfo")]
    public partial class UserInfo
    {
        /// <summary>
        /// 主键用户id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(50)]
        public string Phone { get; set; }
        /// <summary>
        /// email
        /// </summary>
        [StringLength(50)]
        public string Eamil { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateData { get; set; }
    }
}
