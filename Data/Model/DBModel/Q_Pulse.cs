namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 生成订单号脉冲
    /// </summary>
    public partial class Q_Pulse
    {
        public int id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(100)]
        public string desc { get; set; }

        /// <summary>
        /// 重置
        /// </summary>
        public int IsReset { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
