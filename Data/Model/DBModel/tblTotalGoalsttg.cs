using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DBModel
{
    /// <summary>
    /// 主队赔率
    /// </summary>
    [Table("tblTotalGoalsttg")]
   public class tblTotalGoalsttg
    {
        public string id { get; set; }
        public string s0{ get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string s6 { get; set; }
        public string s7 { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }

    }
}
