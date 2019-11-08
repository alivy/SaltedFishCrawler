using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;
using System.Collections.Specialized;

namespace FishTest
{
    /// <summary>
    /// 奖金计算
    /// </summary>
    [TestClass]
    public class BonusCalculationTest
    {
        /// <summary>
        /// 计算串关理论最高奖金
        /// </summary>
        [TestMethod]
        public void SupremeTheoreticalBonusTest()
        {
            var result = new List<Betting>()
            {
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=2},
                new Betting { MatchId =1,PlayId=1,BettingId=1,Odds=3},
                new Betting { MatchId =2,PlayId=0,BettingId=1,Odds=4},
                new Betting { MatchId =3,PlayId=1,BettingId=1,Odds=5},
            };
            var resList = new List<(int, List<Betting>)>();
            var matchNum = result.GroupBy(x => x.MatchId).ToList(); //获取赛事场数
            int num = 0;
            foreach (var matchId in matchNum)
            {
                var key = matchId.Key;
                var matchs = result.Where(x => x.MatchId.Equals(key)).ToList();
                resList.Add((num, matchs));
                num++;
            }

            var a = abc(0);


            List<int> abc(int key)
            {
                var ts = new List<int>();
                var keyList = resList[key].Item2;
                for (int i = 0; i < keyList.Count(); i++)
                {
                    var aa = keyList[i].Odds;
                    for (int j = 0; j < resList[key + 1].Item2.Count(); j++)
                    {
                        var bb = resList[key + 1].Item2[j].Odds;
                        for (int k = 0; k < resList[key + 2].Item2.Count(); k++)
                        {
                            var cc = resList[key + 2].Item2[k].Odds;
                            ts.Add((int)(aa * bb * cc));
                        }
                    }
                }
                return ts;
            }




            int[] index = new int[matchNum.Count];
            while (true)
            {
                List<Betting> strList = new List<Betting>();
                for (int i = 0; i < index.Length; i++)
                {
                    strList.Add(resList[i].Item2[index[i]]);
                }
                int last = index.Length - 1;
                index[last]++;
                for (int i = last; i > 0; i--)
                {
                    if (index[i] == resList[i].Item2.Count)
                    {
                        index[i] = 0;
                        index[i - 1]++;
                        resList.Add((resList[i].Item1, strList));
                    }
                }
                if (index[0] >= resList[0].Item2.Count)
                {
                    break;
                }
            }
            var tt = resList.Distinct().ToList();
        }

        [TestMethod]
        public void BonusTest()
        {
            //数据
            List<(int, int)> data = new List<(int, int)>
            {
                (1,1),(1,0),
                (2,1),(2,0),
                (3,0)
            };

            var a1s = data.GroupBy(x => x.Item1).Select(t => t).ToList();
            var a2s = data.GroupBy(x => x.Item2).Select(t => t).ToList();

            List<List<(int, int)>> ps1 = new List<List<(int, int)>>();
            foreach (var a1 in a1s)
            {
                var b1s = new List<(int, int)>();
                foreach (var a2 in a2s)
                {
                    b1s.Add((a1.Key, a2.Key));
                }
                ps1.Add(b1s);
            }


            //结果
            List<List<(int, int)>> ps = new List<List<(int, int)>>();
            List<(int, int)> a = new List<(int, int)> { (1, 1), (2, 1), (3, 0) };
            List<(int, int)> b = new List<(int, int)> { (1, 1), (2, 0), (3, 0) };
            List<(int, int)> c = new List<(int, int)> { (1, 0), (2, 1), (3, 0) };
            List<(int, int)> d = new List<(int, int)> { (1, 0), (2, 0), (3, 0) };
            ps.Add(a);
            ps.Add(b);
            ps.Add(c);
            ps.Add(d);
        }

        [TestMethod]
        public void MainTest()
        {
            string[][] data = new string[][] {
                new string[]{ "1-0","1-1"},
                new string[]{ "2-0","2-1"},
                new string[]{ "3-1"}
                    };
            int[] index = new int[data.Length];
            List<List<string>> resList = new List<List<string>>();
            //int last = index.Length - 1;
            //for (int i = last; i > 0; i--)
            //{
            //    List<string> strList = new List<string>();
            //    for (int a = 0; a < data[i].Length; a++)
            //    {
            //        for (int j = 0; j < index.Length; j++)
            //        {
            //            strList.Add(data[j][index[i]]);
            //        }
            //    }
            //    if (index[i] == data[i].Length)
            //    {
            //        index[i] = 0;
            //        index[i - 1]++;
            //    }
            //    resList.Add(strList);
            //}



            while (true)
            {
                List<string> strList = new List<string>();
                for (int i = 0; i < index.Length; i++)
                {
                    strList.Add(data[i][index[i]]);
                }
                int last = index.Length - 1;
                index[last]++;
                for (int i = last; i > 0; i--)
                {
                    if (index[i] == data[i].Length)
                    {
                        index[i] = 0;
                        index[i - 1]++;
                        resList.Add(strList);
                    }
                }
                if (index[0] >= data[0].Length)
                {
                    break;
                }
            }
            var a = resList.Distinct();
        }

        [TestMethod]
        public void MainTest1()
        {
            string[][] data = new string[][]
            {
            new string[]{ "1-0","1-1"},
            new string[]{ "2-0","2-1"},
            new string[]{ "3-1"}
            };

            var r = data[0].AsQueryable();
            for (int i = 1; i < data.Length; i++)
            {
                r = r.Join(data[i], (x) => true, (x) => true, (a, b) => a + " " + b);
            }
            foreach (var item in r.ToArray())
            {
                Console.WriteLine(item);
            }
        }



        public void tt()
        {

        }


        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 };

            Hashtable ht = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                var cc = target - nums[i];
                if (ht.ContainsKey(cc))
                {
                    return new int[] { i, (int)ht[cc] };
                }
                if (ht.ContainsKey(nums[i]))
                    ht.Add(nums[i], i);
            }
            return new int[] { -1, -1 };
        }
    }

    /// <summary>
    /// 投注详情
    /// </summary>
    public class CombinationBet
    {
        /// <summary>
        /// item1 赛事ID
        /// </summary>
        public List<Betting> MatchIds { get; set; }
    }



    public class Betting
    {
        /// <summary>
        /// 赛事Id 
        /// </summary>
        public int MatchId { get; set; }
        /// <summary>
        /// 玩法Id  0让球胜平负  1胜平负
        /// </summary>
        public int PlayId { get; set; }

        /// <summary>
        /// 投注Id 0胜 1平 2负
        /// </summary>
        public int BettingId { get; set; }

        /// <summary>
        /// 赔率
        /// </summary>
        public double Odds { get; set; }

    }
}
