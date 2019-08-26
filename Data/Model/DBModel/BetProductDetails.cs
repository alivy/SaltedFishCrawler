namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BetProductDetails
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal ProductMoney { get; set; }

        public int ColourTypes { get; set; }

        public int ColourPalyType { get; set; }

        [StringLength(50)]
        public string BetInfo { get; set; }

        [StringLength(200)]
        public string ProductDescribe { get; set; }
    }
}
