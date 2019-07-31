using BLL;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiCaiWebCore.Controllers
{
    public class FootballMatchController : Controller
    {
        // GET: FootballMatch
        public ActionResult GetFootballMatch(ReqFootballMatch football)
        {
            if (football != null)
            {
                if (football.Type == "Winorlose")
                {
                    FootballMatchBLL bll = new FootballMatchBLL();
                    var winorlose = bll.GetWinOrLoseList();
                    if (winorlose != null && winorlose.Count > 0)
                    {
                        return Json(winorlose);
                    }
                }
            }
            return Json("暂无赛事数据");
        }
    }
}