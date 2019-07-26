namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JieCaiTable")]
    public partial class JieCaiTable
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
