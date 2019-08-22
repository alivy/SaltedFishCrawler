using Data.Enums;
using Data.Enums.FootballGameEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.CustomAttribute;

namespace Data.Model.ViewModel
{
    /// <summary>
    /// 购买足彩数据请求
    /// </summary>
    public class ReqBuyFullLottery
    {
        /// <summary>
        /// 下注数量
        /// </summary>
        public int Multiple { get; set; }

        /// <summary>
        /// 玩法类型  参考<see cref="Data.Enums.FootballGameTypeEnum">
        /// </summary>
        public int PassType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public List<BetContent> Content { get; set; }

    }
    /// <summary>
    /// 投注内容
    /// </summary>
    public class BetContent
    {
        /// <summary>
        /// 赛事id
        /// </summary>
        public int MatchId { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        public List<PlayBetDetails> PlayTypeList { get; set; }

    }

    /// <summary>
    /// 玩法投注详情
    /// </summary>
    public class PlayBetDetails
    {
        /// <summary>
        /// 玩法类型  参考<see cref="FootballGameTypeEnum">
        /// </summary>
        public int SpType { get; set; }

        /// <summary>
        /// 下注数据
        /// </summary>
        public List<string> SpList { get; set; }

        /// <summary>
        /// 解析下注数据
        ///  item1 :胜平负类型
        ///  item2 :赔率
        /// </summary>
        /// <returns></returns>
        public List<(int, double)> SpListanAlysis()
        {
            List<(int, double)> spList = new List<(int, double)>();
            foreach (var item in SpList)
            {

                var tList = item.Split('-').ToList();
                var typeName = tList[0].ToString();
                var odds = double.Parse(tList[0]);
                int winOrLoseType = WinOrLoseQuery(typeName);
                spList.Add((winOrLoseType, odds));
            }
            return spList;
        }

        /// <summary>
        /// 查询胜平负枚举
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int WinOrLoseQuery(string name)
        {
            int enumNum = 0;
            foreach (int val in Enum.GetValues(typeof(WinOrLoseEnum)))
            {
                string strName = Enum.GetName(typeof(WinOrLoseEnum), val);
                if (name.Equals(strName))
                {
                    enumNum = val;
                    break;
                }
            }
            return enumNum;
        }
    }
}
