using BLL;
using Data.Enums;
using Data.Model.ViewModel;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils.Expand;

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
            if (!ModelState.IsValid)
            {
                var errorMsg = ModelState.FristModelStateErrors().FirstOrDefault(); ;
                return Json(ResMessage.CreatMessage(ResultMessageEnum.ValidateError, errorMsg));
            }
            if (football != null)
            {
                if (football.FootballGameType == (int)FootballGameTypeEnum.WinOrLose)
                {
                    FootballMatchBLL bll = new FootballMatchBLL();
                    var winorlose = bll.GetWinOrLoseList();
                    if (winorlose != null && winorlose.Count > 0)
                    {
                        var result = ResMessage.CreatMessage(ResultMessageEnum.Success, winorlose);
                        return Json(result);
                    }
                }
            }
            return Json(ResMessage.CreatMessage(ResultMessageEnum.Error, "暂无赛事数据"));
        }
    }
}