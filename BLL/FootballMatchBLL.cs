using Data.FootballGameModel;
using Data.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Data.Model.ViewModel;
using WorkFlow.FootballGameCrawler;
using Data.FootballGameModel.TotalGoals;
using Data.FootballGameModel.MatchScore;
using Data.FootballGameModel.HalfCourtNegative;

namespace BLL
{
    public class FootballMatchBLL : BaseBLL<tblFootballMatch>
    {
        public override void SetDal()
        {
            _baseDal = new FootballMatchDal();
        }
        /// <summary>
        /// 根据赛事id获取赛事详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tblFootballMatch GetMatchInfo(string id)
        {
            return (_baseDal as FootballMatchDal).GetMatchInfo(id);
        }

        /// <summary>
        /// 胜负平赔率查询
        /// </summary>
        /// <returns></returns>
        public ResFootMatchBase<Odds> GetWinOrLoseList()
        {
            var list = new ResFootMatchBase<Odds>();
            list.dayRaceVoList = new List<dayRaceVoList<Odds>>();
          
            foreach (ResWinOrLose item in (_baseDal as FootballMatchDal).GetWinOrLoseList())
            {
                var day = new dayRaceVoList<Odds>();
                day.raceVoList = new List<raceVoList<Odds>>();
                var race = new raceVoList<Odds>();
                race.bfOdds = new Odds();
                string strdate = "";
                for (int i = 0; i < list.dayRaceVoList.Count(); i++)
                {
                    if (item.date == list.dayRaceVoList[i].date)
                    {
                        race.id = item.id;
                        race.num = item.num;
                        race.date = item.date;
                        race.time = item.time;
                        race.h_cn_abbr = item.h_cn_abbr;
                        race.a_cn_abbr = item.a_cn_abbr;
                        race.h_order = item.h_order;
                        race.a_order = item.a_order;
                        race.weather = item.weather;
                        race.temperature = item.temperature;
                        race.weather_pic = item.weather_pic;
                        race.l_cn = item.l_cn;
                        race.l_cn_abbr = item.l_cn_abbr;
                        race.bfOdds.a = item.a;
                        race.bfOdds.d = item.d;
                        race.bfOdds.h = item.h;
                        list.dayRaceVoList[i].raceVoList.Add(race);
                        strdate = "1";

                    }
                }
                if (strdate == "1")
                {
                    continue;
                }
                day.date = item.date;
                day.week = item.num;
                race.id = item.id;
                race.num = item.num;
                race.date = item.date;
                race.time = item.time;
                race.h_cn_abbr = item.h_cn_abbr;
                race.a_cn_abbr = item.a_cn_abbr;
                race.h_order = item.h_order;
                race.a_order = item.a_order;
                race.weather = item.weather;
                race.temperature = item.temperature;
                race.weather_pic = item.weather_pic;
                race.l_cn = item.l_cn;
                race.l_cn_abbr = item.l_cn_abbr;
                race.bfOdds.a = item.a;
                race.bfOdds.d = item.d;
                race.bfOdds.h = item.h;
                day.raceVoList.Add(race);

                list.dayRaceVoList.Add(day);
            }

            return list;
        }

        /// <summary>
        /// 总比分赔率查询
        /// </summary>
        /// <returns></returns>
        public ResFootMatchBase<TotalGoals> GetTotalGoalsList()
        {
            var list = new ResFootMatchBase<TotalGoals>();
            list.dayRaceVoList = new List<dayRaceVoList<TotalGoals>>();

            foreach (ResTotalGoals item in (_baseDal as FootballMatchDal).GetTotalGoalsList())
            {
                var day = new dayRaceVoList<TotalGoals>();
                day.raceVoList = new List<raceVoList<TotalGoals>>();
                var race = new raceVoList<TotalGoals>();
                race.bfOdds = new TotalGoals();
                string strdate = "";
                for (int i = 0; i < list.dayRaceVoList.Count(); i++)
                {
                    if (item.date == list.dayRaceVoList[i].date)
                    {
                        race.id = item.id;
                        race.num = item.num;
                        race.date = item.date;
                        race.time = item.time;
                        race.h_cn_abbr = item.h_cn_abbr;
                        race.a_cn_abbr = item.a_cn_abbr;
                        race.h_order = item.h_order;
                        race.a_order = item.a_order;
                        race.weather = item.weather;
                        race.temperature = item.temperature;
                        race.weather_pic = item.weather_pic;
                        race.l_cn = item.l_cn;
                        race.l_cn_abbr = item.l_cn_abbr;
                        race.bfOdds.s0 = item.s0;
                        race.bfOdds.s1 = item.s1;
                        race.bfOdds.s2 = item.s2;
                        race.bfOdds.s3 = item.s3;
                        race.bfOdds.s4 = item.s4;
                        race.bfOdds.s5 = item.s5;
                        race.bfOdds.s6 = item.s6;
                        race.bfOdds.s7 = item.s7;
                        list.dayRaceVoList[i].raceVoList.Add(race);
                        strdate = "1";

                    }
                }
                if (strdate == "1")
                {
                    continue;
                }
                day.date = item.date;
                day.week = item.num;
                race.id = item.id;
                race.num = item.num;
                race.date = item.date;
                race.time = item.time;
                race.h_cn_abbr = item.h_cn_abbr;
                race.a_cn_abbr = item.a_cn_abbr;
                race.h_order = item.h_order;
                race.a_order = item.a_order;
                race.weather = item.weather;
                race.temperature = item.temperature;
                race.weather_pic = item.weather_pic;
                race.l_cn = item.l_cn;
                race.l_cn_abbr = item.l_cn_abbr;
                race.bfOdds.s0 = item.s0;
                race.bfOdds.s1 = item.s1;
                race.bfOdds.s2 = item.s2;
                race.bfOdds.s3 = item.s3;
                race.bfOdds.s4 = item.s4;
                race.bfOdds.s5 = item.s5;
                race.bfOdds.s6 = item.s6;
                race.bfOdds.s7 = item.s7;
                day.raceVoList.Add(race);

                list.dayRaceVoList.Add(day);
            }
            return list;
        }

        /// <summary>
        /// 比分赔率查询
        /// </summary>
        /// <returns></returns>
        public ResFootMatchBase<MatchScore> GetMatchScoreList()
        {
            var list = new ResFootMatchBase<MatchScore>();
            list.dayRaceVoList = new List<dayRaceVoList<MatchScore>>();

            foreach (ResMatchScore item in (_baseDal as FootballMatchDal).GetMatchScoreList())
            {
                var day = new dayRaceVoList<MatchScore>();
                day.raceVoList = new List<raceVoList<MatchScore>>();
                var race = new raceVoList<MatchScore>();
                race.bfOdds = new MatchScore();
                string strdate = "";
                for (int i = 0; i < list.dayRaceVoList.Count(); i++)
                {
                    if (item.date == list.dayRaceVoList[i].date)
                    {
                        race.id = item.id;
                        race.num = item.num;
                        race.date = item.date;
                        race.time = item.time;
                        race.h_cn_abbr = item.h_cn_abbr;
                        race.a_cn_abbr = item.a_cn_abbr;
                        race.h_order = item.h_order;
                        race.a_order = item.a_order;
                        race.weather = item.weather;
                        race.temperature = item.temperature;
                        race.weather_pic = item.weather_pic;
                        race.l_cn = item.l_cn;
                        race.l_cn_abbr = item.l_cn_abbr;
                        race.bfOdds.s1 =item.s1  ;
                        race.bfOdds.s2 =item.s2  ;
                        race.bfOdds.s3 =item.s3  ;
                        race.bfOdds.s4 =item.s4  ;
                        race.bfOdds.s5 =item.s5  ;
                        race.bfOdds.s6 =item.s6  ;
                        race.bfOdds.s7 =item.s7  ;
                        race.bfOdds.s8 =item.s8  ;
                        race.bfOdds.s9 =item.s9  ;
                        race.bfOdds.s10=item.s10 ;
                        race.bfOdds.s11=item.s11 ;
                        race.bfOdds.s12=item.s12 ;
                        race.bfOdds.s13=item.s13 ;
                        race.bfOdds.s14=item.s14 ;
                        race.bfOdds.s15=item.s15 ;
                        race.bfOdds.s16=item.s16 ;
                        race.bfOdds.s17=item.s17 ;
                        race.bfOdds.s18=item.s18 ;
                        race.bfOdds.s19=item.s19 ;
                        race.bfOdds.s20=item.s20 ;
                        race.bfOdds.s21=item.s21 ;
                        race.bfOdds.s22=item.s22 ;
                        race.bfOdds.s23=item.s23 ;
                        race.bfOdds.s24=item.s24 ;
                        race.bfOdds.s25=item.s25 ;
                        race.bfOdds.s26=item.s26 ;
                        race.bfOdds.s27=item.s27 ;
                        race.bfOdds.s28=item.s28 ;
                        race.bfOdds.s29=item.s29 ;
                        race.bfOdds.s30 = item.s30;
                        list.dayRaceVoList[i].raceVoList.Add(race);
                        strdate = "1";

                    }
                }
                if (strdate == "1")
                {
                    continue;
                }
                day.date = item.date;
                day.week = item.num;
                race.id = item.id;
                race.num = item.num;
                race.date = item.date;
                race.time = item.time;
                race.h_cn_abbr = item.h_cn_abbr;
                race.a_cn_abbr = item.a_cn_abbr;
                race.h_order = item.h_order;
                race.a_order = item.a_order;
                race.weather = item.weather;
                race.temperature = item.temperature;
                race.weather_pic = item.weather_pic;
                race.l_cn = item.l_cn;
                race.l_cn_abbr = item.l_cn_abbr;
                race.bfOdds.s1 = item.s1;
                race.bfOdds.s2 = item.s2;
                race.bfOdds.s3 = item.s3;
                race.bfOdds.s4 = item.s4;
                race.bfOdds.s5 = item.s5;
                race.bfOdds.s6 = item.s6;
                race.bfOdds.s7 = item.s7;
                race.bfOdds.s8 = item.s8;
                race.bfOdds.s9 = item.s9;
                race.bfOdds.s10 = item.s10;
                race.bfOdds.s11 = item.s11;
                race.bfOdds.s12 = item.s12;
                race.bfOdds.s13 = item.s13;
                race.bfOdds.s14 = item.s14;
                race.bfOdds.s15 = item.s15;
                race.bfOdds.s16 = item.s16;
                race.bfOdds.s17 = item.s17;
                race.bfOdds.s18 = item.s18;
                race.bfOdds.s19 = item.s19;
                race.bfOdds.s20 = item.s20;
                race.bfOdds.s21 = item.s21;
                race.bfOdds.s22 = item.s22;
                race.bfOdds.s23 = item.s23;
                race.bfOdds.s24 = item.s24;
                race.bfOdds.s25 = item.s25;
                race.bfOdds.s26 = item.s26;
                race.bfOdds.s27 = item.s27;
                race.bfOdds.s28 = item.s28;
                race.bfOdds.s29 = item.s29;
                race.bfOdds.s30 = item.s30;
                day.raceVoList.Add(race);

                list.dayRaceVoList.Add(day);
            }

            return list;
        }

        /// <summary>
        /// 半全场平负赔率数据查询
        /// </summary>
        /// <returns></returns>
        public ResFootMatchBase<HalfCourtNegative> GetHalfCourtNegativeList()
        {

            var list = new ResFootMatchBase<HalfCourtNegative>();
            list.dayRaceVoList = new List<dayRaceVoList<HalfCourtNegative>>();

            foreach (ResHalfCourtNegative item in (_baseDal as FootballMatchDal).GetHalfCourtNegativeList())
            {
                var day = new dayRaceVoList<HalfCourtNegative>();
                day.raceVoList = new List<raceVoList<HalfCourtNegative>>();
                var race = new raceVoList<HalfCourtNegative>();
                race.bfOdds = new HalfCourtNegative();
                string strdate = "";
                for (int i = 0; i < list.dayRaceVoList.Count(); i++)
                {
                    if (item.date == list.dayRaceVoList[i].date)
                    {
                        race.id = item.id;
                        race.num = item.num;
                        race.date = item.date;
                        race.time = item.time;
                        race.h_cn_abbr = item.h_cn_abbr;
                        race.a_cn_abbr = item.a_cn_abbr;
                        race.h_order = item.h_order;
                        race.a_order = item.a_order;
                        race.weather = item.weather;
                        race.temperature = item.temperature;
                        race.weather_pic = item.weather_pic;
                        race.l_cn = item.l_cn;
                        race.l_cn_abbr = item.l_cn_abbr;
                        race.bfOdds.aa=item.aa;
                        race.bfOdds.ad=item.ad;
                        race.bfOdds.ah=item.ah;
                        race.bfOdds.da=item.da;
                        race.bfOdds.dd=item.dd;
                        race.bfOdds.dh=item.dh;
                        race.bfOdds.ha=item.ha;
                        race.bfOdds.hd=item.hd;
                        race.bfOdds.hh = item.hh;

                        list.dayRaceVoList[i].raceVoList.Add(race);
                        strdate = "1";

                    }
                }
                if (strdate == "1")
                {
                    continue;
                }
                day.date = item.date;
                day.week = item.num;
                race.id = item.id;
                race.num = item.num;
                race.date = item.date;
                race.time = item.time;
                race.h_cn_abbr = item.h_cn_abbr;
                race.a_cn_abbr = item.a_cn_abbr;
                race.h_order = item.h_order;
                race.a_order = item.a_order;
                race.weather = item.weather;
                race.temperature = item.temperature;
                race.weather_pic = item.weather_pic;
                race.l_cn = item.l_cn;
                race.l_cn_abbr = item.l_cn_abbr;
                race.bfOdds.aa = item.aa;
                race.bfOdds.ad = item.ad;
                race.bfOdds.ah = item.ah;
                race.bfOdds.da = item.da;
                race.bfOdds.dd = item.dd;
                race.bfOdds.dh = item.dh;
                race.bfOdds.ha = item.ha;
                race.bfOdds.hd = item.hd;
                race.bfOdds.hh = item.hh;
                day.raceVoList.Add(race);

                list.dayRaceVoList.Add(day);
            }
            return list;
        }

        /// <summary>
        /// 同步最新赛事和胜平负赔率
        /// </summary>
        public void WinOrLoseTest()
        {
            ISearch search = new WinOrLoseSearch();
            var winOrLose = (WinOrLoseDate)search.Process();

            if (winOrLose != null && winOrLose.data.Count > 0)
            {
                foreach (Data.FootballGameModel.data item in winOrLose.data)
                {
                    var tt = new FootballMatchBLL().GetMatchInfo(item.id);
                    var tt1 = new BaseBLL<tblWinOrLosehad>().FirstOrDefault(x => x.id.Equals(item.id));
                    var tt2 = new BaseBLL<tblWinOrLosehhad>().FirstOrDefault(x => x.id.Equals(item.id));
                    if (tt != null)
                    {
                        tt.num = item.num;
                        tt.date = item.date;
                        tt.time = item.time;
                        tt.h_cn_abbr = item.h_cn_abbr;
                        tt.a_cn_abbr = item.a_cn_abbr;
                        tt.h_order = item.h_order;
                        tt.a_order = item.a_order;
                        tt.weather = item.weather;
                        tt.temperature = item.temperature;
                        tt.weather_pic = item.weather_pic;
                        tt.l_cn = item.l_cn;
                        tt.l_cn_abbr = item.l_cn;
        new BaseBLL<tblFootballMatch>().UpdateEntity(tt);
                    }
                    else
                    {
                        new BaseBLL<tblFootballMatch>().AddEntity(new tblFootballMatch
                        {
                            id = item.id,
                            num = item.num,
                            date = item.date,
                            time = item.time,
                            h_cn_abbr = item.h_cn_abbr,
                            a_cn_abbr = item.a_cn_abbr,
                            h_order = item.h_order,
                            a_order = item.a_order,
                            weather = item.weather,
                            temperature = item.temperature,
                            weather_pic = item.weather_pic
                        });
                    }
                    if (tt1 != null)
                    {
                        tt1.a = item.had.a;
                        tt1.d = item.had.d;
                        tt1.h = item.had.h;
                        new BaseBLL<tblWinOrLosehad>().UpdateEntity(tt1);
                    }
                    else
                    {
                        new BaseBLL<tblWinOrLosehad>().AddEntity(new tblWinOrLosehad
                        {
                            id = item.id,
                            a = item.had.a,
                            d = item.had.d,
                            h = item.had.h
                        });
                    }
                    if (tt2 != null)
                    {
                        tt2.id = item.id;
                        tt2.a = item.hhad.a;
                        tt2.d = item.hhad.d;
                        tt2.h = item.hhad.h;
                        new BaseBLL<tblWinOrLosehhad>().UpdateEntity(tt2);
                    }
                    else
                    {
                        new BaseBLL<tblWinOrLosehhad>().AddEntity(new tblWinOrLosehhad
                        {
                            id = item.id,
                            a = item.hhad.a,
                            d = item.hhad.d,
                            h = item.hhad.h
                        });
                    }
                }

            }
        }

        /// <summary>
        /// 同步总进球数赔率数据
        /// </summary>
        public void TotalGoalsTest()
        {
            ISearch search = new TotalGoalsSearch();
            var total = (TotalGoalsDate)search.Process();

            if (total != null && total.data.Count > 0)
            {
                foreach (Data.FootballGameModel.TotalGoals.data item in total.data)
                {
                    var tt1 = new BaseBLL<tblTotalGoalsttg>().FirstOrDefault(x => x.id.Equals(item.id));
                    if (tt1 != null)
                    {
                        tt1.s0 = item.ttg.s0;
                        tt1.s1 = item.ttg.s1;
                        tt1.s2 = item.ttg.s2;
                        tt1.s3 = item.ttg.s3;
                        tt1.s4 = item.ttg.s4;
                        tt1.s5 = item.ttg.s5;
                        tt1.s6 = item.ttg.s6;
                        tt1.s7 = item.ttg.s7;

                        new BaseBLL<tblTotalGoalsttg>().UpdateEntity(tt1);
                    }
                    else
                    {
                        new BaseBLL<tblTotalGoalsttg>().AddEntity(new tblTotalGoalsttg
                        {
                            id = item.id,
                            s0 = item.ttg.s0,
                            s1 = item.ttg.s1,
                            s2 = item.ttg.s2,
                            s3 = item.ttg.s3,
                            s4 = item.ttg.s4,
                            s5 = item.ttg.s5,
                            s6 = item.ttg.s6,
                            s7 = item.ttg.s7
                        });
                    }
                }
            }
        }
        /// <summary>
        /// 同步比分赔率数据
        /// </summary>
        public void MatchScoreTest()
        {
            ISearch search = new MatchScoreSearch();
            var match = (MatchScoreDate)search.Process();

            if (match != null && match.data.Count > 0)
            {
                foreach (Data.FootballGameModel.MatchScore.data item in match.data)
                {
                    var tt1 = new BaseBLL<tblMatchScorecrs>().FirstOrDefault(x => x.id.Equals(item.id));
                    if (tt1 != null)
                    {
                        tt1.s1 = item.crs.s1;
                        tt1.s2 = item.crs.s2;
                        tt1.s3 = item.crs.s3;
                        tt1.s4 = item.crs.s4;
                        tt1.s5 = item.crs.s5;
                        tt1.s6 = item.crs.s6;
                        tt1.s7 = item.crs.s7;
                        tt1.s8 = item.crs.s8;
                        tt1.s9 = item.crs.s9;
                        tt1.s10 = item.crs.s10;
                        tt1.s11 = item.crs.s11;
                        tt1.s12 = item.crs.s12;
                        tt1.s13 = item.crs.s13;
                        tt1.s14 = item.crs.s14;
                        tt1.s15 = item.crs.s15;
                        tt1.s16 = item.crs.s16;
                        tt1.s17 = item.crs.s17;
                        tt1.s18 = item.crs.s18;
                        tt1.s19 = item.crs.s19;
                        tt1.s20 = item.crs.s20;
                        tt1.s21 = item.crs.s21;
                        tt1.s22 = item.crs.s22;
                        tt1.s23 = item.crs.s23;
                        tt1.s24 = item.crs.s24;
                        tt1.s25 = item.crs.s25;
                        tt1.s26 = item.crs.s26;
                        tt1.s27 = item.crs.s27;
                        tt1.s28 = item.crs.s28;
                        tt1.s29 = item.crs.s29;
                        tt1.s30 = item.crs.s30;
                    }
                    else
                    {
                        new BaseBLL<tblMatchScorecrs>().AddEntity(new tblMatchScorecrs
                        {
                            id = item.id,
                            s1 = item.crs.s1,
                            s2 = item.crs.s2,
                            s3 = item.crs.s3,
                            s4 = item.crs.s4,
                            s5 = item.crs.s5,
                            s6 = item.crs.s6,
                            s7 = item.crs.s7,
                            s8 = item.crs.s8,
                            s9 = item.crs.s9,
                            s10 = item.crs.s10,
                            s11 = item.crs.s11,
                            s12 = item.crs.s12,
                            s13 = item.crs.s13,
                            s14 = item.crs.s14,
                            s15 = item.crs.s15,
                            s16 = item.crs.s16,
                            s17 = item.crs.s17,
                            s18 = item.crs.s18,
                            s19 = item.crs.s19,
                            s20 = item.crs.s20,
                            s21 = item.crs.s21,
                            s22 = item.crs.s22,
                            s23 = item.crs.s23,
                            s24 = item.crs.s24,
                            s25 = item.crs.s25,
                            s26 = item.crs.s26,
                            s27 = item.crs.s27,
                            s28 = item.crs.s28,
                            s29 = item.crs.s29,
                            s30 = item.crs.s30
                        });
                    }
                }

            }
        }
        /// <summary>
        /// 同步半全场平负赔率数据
        /// </summary>
        public void HalfCourtNegativeTest()
        {
            ISearch search = new HalfCourtNegativeSearch();
            var half = (HalfCourtNegativeDate)search.Process();

            if (half != null && half.data.Count > 0)
            {
                foreach (Data.FootballGameModel.HalfCourtNegative.data item in half.data)
                {
                    var tt1 = new BaseBLL<tblHalfCourtNegativehafu>().FirstOrDefault(x => x.id.Equals(item.id));
                    if (tt1 != null)
                    {
                        tt1.aa = item.hafu.aa;
                        tt1.ad = item.hafu.ad;
                        tt1.ah = item.hafu.ah;
                        tt1.da = item.hafu.da;
                        tt1.dd = item.hafu.dd;
                        tt1.dh = item.hafu.dh;
                        tt1.ha = item.hafu.ha;
                        tt1.hd = item.hafu.hd;
                        tt1.hh = item.hafu.hh;
                    }
                    else
                    {
                        new BaseBLL<tblHalfCourtNegativehafu>().AddEntity(new tblHalfCourtNegativehafu
                        {
                            id = item.id,
                            aa = item.hafu.aa,
                            ad = item.hafu.ad,
                            ah = item.hafu.ah,
                            da = item.hafu.da,
                            dd = item.hafu.dd,
                            dh = item.hafu.dh,
                            ha = item.hafu.ha,
                            hd = item.hafu.hd,
                            hh = item.hafu.hh
                        });
                    }
                }
            }

        }
    }
}
