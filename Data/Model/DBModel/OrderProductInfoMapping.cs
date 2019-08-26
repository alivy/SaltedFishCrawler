namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderProductInfoMapping")]
    public partial class OrderProductInfoMapping
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNo订单号 { get; set; }

        public int ProductMoney { get; set; }

        public double BetMoney { get; set; }

        public int ProductId { get; set; }
    }
}
