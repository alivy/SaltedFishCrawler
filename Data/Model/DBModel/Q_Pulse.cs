namespace Data.Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Éú³É¶©µ¥ºÅÂö³å
    /// </summary>
    public partial class Q_Pulse
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int Num { get; set; }

        public DateTime AddTime { get; set; }

        [StringLength(100)]
        public string desc { get; set; }

        public int IsReset { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
