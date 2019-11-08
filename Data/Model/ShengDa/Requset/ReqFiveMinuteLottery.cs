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

        public string One { get; set; }

        public string Two { get; set; }

        public string Three { get; set; }

        public string Four { get; set; }

        public string Five { get; set; }

        public string OpenTime { get; set; }
    }
}
