using BLL;
using Data.Enums;
using Data.Model.ViewModel;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiCaiWebCore.Controllers
{
    public class FootballMatchController : Controller
    {
       /// <summary>
       /// 赛事数据查询
       /// </summary>
       /// <param name="football"></param>
       /// <returns></returns>
        public ActionResult GetFootballMatch(ReqFootballMatch football)
        {
            if (football != null)
            {
                FootballMatchBLL bll = new FootballMatchBLL();
                if (football.FootballGameType == (int)FootballGameTypeEnum.WinOrLose)
                {
                    var winorlose = bll.GetWinOrLoseList();
                    if (winorlose != null && winorlose.Count > 0)
                    {
                        var result = ResMessage.CreatMessage(ResultMessageEnum.Success, winorlose);
                        return Json(result);
                    }
                }
                else if (football.FootballGameType == (int)FootballGameTypeEnum.TotalGoals)
                {
                    var totalGoals = bll.GetWinOrLoseList();
                    if (totalGoals != null && totalGoals.Count > 0)
                    {
                        var result = ResMessage.CreatMessage(ResultMessageEnum.Success, totalGoals);
                        return Json(result);
                    }
                }
                else if (football.FootballGameType == (int)FootballGameTypeEnum.Score)
                {
                    var score = bll.GetWinOrLoseList();
                    if (score != null && score.Count > 0)
                    {
                        var result = ResMessage.CreatMessage(ResultMessageEnum.Success, score);
                        return Json(result);
                    }
                }
                else if (football.FootballGameType == (int)FootballGameTypeEnum.HalfCourtNegative)
                {
                    var half = bll.GetWinOrLoseList();
                    if (half != null && half.Count > 0)
                    {
                        var result = ResMessage.CreatMessage(ResultMessageEnum.Success, half);
                        return Json(result);
                    }
                }
            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "暂无赛事数据"));
        }
    }
}