using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FishTest
{
    [TestClass]
    public class LotteryAnalysis
    {

        //开奖信息
        public static List<int> 个 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        public static List<int> 十 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        public static List<int> 百 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        public static List<int> 千 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        public static List<int> 万 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        /// <summary>
        /// 3、“五星通选”玩法特点
        ///①、玩法简单、中奖容易
        ///“五星通选”是从0-9任选5个数进行投注，选号时各位置上所选数字可以有相同数。选号简单、玩法灵活、选中5个数的中奖机会是1/100000，
        ///   选中3个数的中奖机会是1/1000，
        ///   选中2个数的中奖机会是1/100，
        ///属于中奖概率大的游戏。
        ///②、两元一注号码，五次中奖机会
        ///“五星通选”设3个奖级，全部为固定奖。
        ///   两元一注号码，三个奖级通吃，五次中奖机会。
        ///即使选对5个数，要是选中了“前三”、“后三”或者“前对”、“后对”都可中奖。
        ///③、每注号码可兼中兼得，彩民可得更多的实惠。
        ///“五星通选”游戏规则明确：当期每注号码可兼中兼得。下注2元钱，
        ///   如果选中一等奖号码，就可以通吃一、二、三等奖，这给彩民朋友带来了更多实惠。这是“五星通选”玩法吸引人的最大卖点。
        ///④、名词解释：
        ///“前三”：所选号码前面的连续三位数，例如：“96007”投注号码的前三位数是“960”简称“前三”。对奖时当期前面连续三位数与开奖号码相同且顺序一致，即中二等奖。
        ///例如：选‘96003’投注“五星通选”，当期开奖号码‘96045’，投注号码的前三位数‘960’与开奖号码按位置完全相同，即中二等奖，奖金200元。
        ///“后三”：所选号码后面的连续三位数，例如：‘96007’投注号码的后三位数是‘007’简称‘后三’。对奖时当期后面连续三位数与开奖号码相同且顺序一致，也可中二等奖。
        ///例如：选‘98045’投注“五星通选”，当期开奖号码‘96045’，投注号码的后三位数‘045’与开奖号码按位置完全相同，即中二等奖，奖金200元。
        ///“前对”：所选号码前面的连续两位数，例如：“96007”投注号码的前两位数是“96”简称“前对”。对奖时当期前面连续两位数与开奖号码相同且顺序一致，即中三等奖。
        ///例如：选‘96646’投注“五星通选”，当期开奖号码‘96045’，投注号码的前两位数‘96’与开奖号码按位置完全相同，即中三等奖，奖金20元。
        ///“后对”：所选号码后面的连续两位数，例如：‘96007’投注号码的后两位数是‘07’简称‘后对’。对奖时当期后面连续两位数与开奖号码相同且顺序一致，也可中三等奖。
        ///例如：选‘86645’投注“五星通选”，当期开奖号码‘96045’，投注号码的后两位数‘45’与开奖号码按位置完全相同，即中三等奖，奖金20元。
        ///关于时时彩夜间版上市补充说明：
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            all();
            topThree();
        }


        /// <summary>
        /// 前三开奖号码
        /// </summary>
        public void topThree()
        {
            //前对数
            int frontPair = 0;           
            //前三数
            int topThree = 0;
            var 开奖号码 = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (var item1 in 万)
            {
                foreach (var item2 in 千)
                {
                    foreach (var item3 in 百)
                    {
                        if (item1.Equals(开奖号码[0]) && item2.Equals(开奖号码[1]))
                        {
                            frontPair++;
                            if (item3.Equals(开奖号码[2]))
                            {
                                topThree++;
                            }
                        }

                    }
                }
            }
            var frontPairMoney = frontPair * 20;
            var topThreeMoney = topThree * 200;
            var afterTheMoney = frontPair * 20;
            var laterThreeMoney = topThree * 200;
            var allNumMoney = (frontPairMoney + topThreeMoney) * 2;
        }


        /// <summary>
        /// 所有开奖号码
        /// </summary>
        public void all()
        {
            //总数
            int allNum = 0;
            //前对数
            int frontPair = 0;
            //后对数
            int afterThe = 0;
            //前三数
            int topThree = 0;
            //后三数
            int laterThree = 0;

            var 开奖号码 = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (var item1 in 万)
            {
                foreach (var item2 in 千)
                {
                    foreach (var item3 in 百)
                    {
                        foreach (var item4 in 十)
                        {
                            foreach (var item5 in 个)
                            {
                                if (item1.Equals(开奖号码[0]) && item2.Equals(开奖号码[1]))
                                {
                                    frontPair++;
                                    if (item3.Equals(开奖号码[2]))
                                    {
                                        topThree++;
                                    }
                                }
                                if (item3.Equals(开奖号码[4]) && item4.Equals(开奖号码[3]))
                                {
                                    afterThe++;
                                    if (item3.Equals(开奖号码[2]))
                                    {
                                        laterThree++;
                                    }
                                }
                            }
                        }
                    }

                }
            }

            var frontPairMoney = frontPair * 20;
            var topThreeMoney = topThree * 200;
            var afterTheMoney = frontPair * 20;
            var laterThreeMoney = topThree * 200;
            var allNumMoney = (frontPairMoney + topThreeMoney) * 2;

        }




    }
}
