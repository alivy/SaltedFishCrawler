namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserOrder")]
    public partial class UserOrder
    {
        public int Id { get; set; }

       /// <summary>
       /// 订单号
       /// </summary>
        [Required]
        [StringLength(50)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 应付金额
        /// </summary>
        public double CopePayMoney { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        public double ActualPayMoney { get; set; }

        /// <summary>
        /// 订单状态 1.未支付 2.支付中 3.已支付 4.已接单 5.已出票 
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
