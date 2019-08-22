﻿using System.Web;
using System.Web.Mvc;
using WeiCaiWebCore.Filter;

namespace WeiCaiWebCore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //全局注册异常
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}
