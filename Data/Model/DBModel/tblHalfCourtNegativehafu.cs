using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.DBModel
{
    [Table("tblHalfCourtNegativehafu")]
    public class tblHalfCourtNegativehafu
    {
        public string id { get; set; }
        public string aa { get; set; }
        public string ad { get; set; }
        public string ah { get; set; }
        public string da { get; set; }
        public string dd { get; set; }
        public string dh { get; set; }
        public string ha { get; set; }
        public string hd { get; set; }
        public string hh { get; set; }
        public string o_type { get; set; }
        public string single { get; set; }
        public string fixedodds { get; set; }
    }
}
