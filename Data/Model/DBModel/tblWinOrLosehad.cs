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
    [Table("tblWinOrLosehad")]
    public class tblWinOrLosehad
    {
        public string id { get; set; }
        public string a { get; set; }
        public string d { get; set; }
        public string h { get; set; }

        public string b { get; set; }
        public string e { get; set; }
        public string i { get; set; }


    }
}
