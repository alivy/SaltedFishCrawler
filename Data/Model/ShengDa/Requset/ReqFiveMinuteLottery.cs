using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Requset
{
    public class ReqFiveMinuteLottery
    {
        public string issue_no { get; set; }

        public string lotteryopen_no { get; set; }

        public string open_time { get; set; }
    }


    public class ReqFiveMinuteLotteryResult
    {
        public string IssueCode { get; set; }

        public int One { get; set; }

        public int Two { get; set; }

        public int Three { get; set; }

        public int Four { get; set; }

        public int Five { get; set; }

        public string OpenTime { get; set; }
    }
}
