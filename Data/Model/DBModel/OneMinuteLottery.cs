using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DBModel
{
    /// <summary>
    /// 分分彩开奖结果
    /// </summary>
   [Table("OneMinuteLottery")]
    public class OneMinuteLottery
    {
        public string ID { get; set; }

        public int One { get; set; }

        public int Two { get; set; }

        public int Three { get; set; }

        public int Four { get; set; }

        public int Five { get; set; }

        public string OpenTime { get; set; }
    }
}
