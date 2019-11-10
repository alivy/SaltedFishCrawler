using DAL;
using Data.Enums.ShengDaEnum;
using Data.Model.DBModel;
using Data.Model.FiveMinuteLotteryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 五分彩数据逻辑
    /// </summary>
    public class FiveMinuteLotteryBLL : BaseBLL<FiveMinuteLottery>
    {
        public override void SetDal()
        {
            _baseDal = new FiveMinuteLotteryDal();
        }

        /// <summary>
        /// 查询某天最多大小单双练注数
        /// </summary>
        /// <param name="dateTime"></param>
        public FiveMinuteResultAnalysis MaxSingleDoubleOrSize(DateTime dateTime)
        {

            var dataStr = dateTime.ToString("yyyyMMdd");
            var fiveMinuteLotteryList = _baseDal.LoadEntities(x => x.ID.Contains(dataStr)).OrderBy(x => x.ID).ToList();


            var pastFiveMinute = new FiveMinuteLottery();


            List<FiveMinuteResultAnalysis> fiveMinuteResultAnalyses = new List<FiveMinuteResultAnalysis>();
            FiveMinuteResultAnalysis oneFiveMinute = new FiveMinuteResultAnalysis() { DataBits = (int)FiveMinLotteryBettingNumberEnum.one };
            int singleNum = 1;
            int doubleNum = 1;
            int largeNum = 1;
            int sizeNum = 1;
            foreach (var item in fiveMinuteLotteryList)
            {
                if (pastFiveMinute != null)
                {
                    var num = 1;
                    //当前开奖号
                    var lotteryNum = GetLotteryNumber(num, item);
                    //上一注开奖号
                    var pastlotteryNum = GetLotteryNumber(num, pastFiveMinute);
                    if (lotteryNum % 2 == 0 && pastlotteryNum % 2 == 0)
                    {
                        doubleNum++;
                        oneFiveMinute.DoubleNum = doubleNum > oneFiveMinute.DoubleNum ? doubleNum : oneFiveMinute.DoubleNum;
                    }
                    else if (lotteryNum % 2 != 0 && pastlotteryNum % 2 != 0)
                    {
                        singleNum++;
                        oneFiveMinute.SingleNum = singleNum > oneFiveMinute.SingleNum ? singleNum : oneFiveMinute.SingleNum;
                    }
                    else
                    {
                        doubleNum = 1;
                        singleNum = 1;
                    }

                    if (lotteryNum < 5 && pastlotteryNum < 5)
                    {
                        sizeNum++;
                        oneFiveMinute.Size = sizeNum > oneFiveMinute.Size ? sizeNum : oneFiveMinute.Size;
                    }
                    else if (lotteryNum > 5 && pastlotteryNum > 5)
                    {
                        largeNum++;
                        oneFiveMinute.Large = largeNum > oneFiveMinute.Large ? largeNum : oneFiveMinute.Large;
                    }
                    else
                    {
                        sizeNum = 0;
                        largeNum = 0;
                    }
                }
                pastFiveMinute = item;
            }
            return oneFiveMinute;
        }


        /// <summary>
        /// 获取开奖球数据位
        /// </summary>
        /// <param name="ballPosition"></param>
        /// <returns></returns>
        private int GetLotteryNumber(int ballPosition, FiveMinuteLottery fiveMinute)
        {
            var num = 0;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.one)
                num = fiveMinute.One;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.two)
                num = fiveMinute.Two;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.tree)
                num = fiveMinute.Three;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.four)
                num = fiveMinute.Four;
            if (ballPosition == (int)FiveMinLotteryBettingNumberEnum.five)
                num = fiveMinute.Five;
            return num;
        }
    }
}
