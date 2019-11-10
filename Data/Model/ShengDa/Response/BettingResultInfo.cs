using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.ShengDa.Response
{
    /// <summary>
    /// 投注结果信息
    /// </summary>
    public class BettingResultResponse
    {

        /// <summary>
        ///数据源
        /// </summary>
        public List<BettingResultInfoResponse> sourse { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int data_count { get; set; }
        
    }


    /// <summary>
    /// 投注结果详细信息
    /// </summary>
    public class BettingResultInfoResponse
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string guid { get; set; }
        /// <summary>
        /// 彩种编号
        /// </summary>
        public string lottery_code { get; set; }
        /// <summary>
        /// 彩种名称
        /// </summary>
        public string lottery_name { get; set; }
        /// <summary>
        /// 投注期号
        /// </summary>
        public string issue_no { get; set; }
        /// <summary>
        /// 投注数字
        /// </summary>
        public string betting_num { get; set; }
        /// <summary>
        /// 投注金额
        /// </summary>
        public string normal_money { get; set; }
        /// <summary>
        /// 开奖号码 未开----
        /// </summary>
        public string lotteryopen_no { get; set; }
        /// <summary>
        /// 中奖金额
        /// </summary>
        public string bonus_money { get; set; }
        /// <summary>
        /// 投注状态 0处理中 1未中奖 2中奖
        /// </summary>
        public string open_state { get; set; }

        /// <summary>
        /// 投注时间
        /// </summary>
        public string add_time { get; set; }
    }
}
