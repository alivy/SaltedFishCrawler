using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DBModel
{
    /// <summary>
    /// 赛事数据表
    /// </summary>
    [Table("tblFootballMatch")]
    public partial class tblFootballMatch
    {
        [StringLength(50)]
        public string id { get; set; }
        [StringLength(50)]
        public string num { get; set; }
        [StringLength(50)]
        public string date { get; set; }
        [StringLength(50)]
        public string time { get; set; }
        [StringLength(50)]
        public string h_cn_abbr { get; set; }
        [StringLength(50)]
        public string a_cn_abbr { get; set; }
        [StringLength(50)]
        public string h_order { get; set; }
        [StringLength(50)]
        public string a_order { get; set; }
        [StringLength(50)]
        public string weather { get; set; }
        [StringLength(50)]
        public string temperature { get; set; }
        [StringLength(100)]
        public string weather_pic { get; set; }
        [StringLength(100)]
        public string l_cn { get; set; }
        [StringLength(100)]
        public string l_cn_abbr { get; set; }

    }
}
