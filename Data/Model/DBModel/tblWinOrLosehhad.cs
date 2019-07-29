using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DBModel
{
    /// <summary>
    /// 客队赔率
    /// </summary>
    [Table("tblWinOrLosehhad")]
    public   class tblWinOrLosehhad
    {

        public string id { get; set; }
        public string a { get; set; }
        public string d { get; set; }
        public string h { get; set; }
    }
}
