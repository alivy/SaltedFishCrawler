using BLL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeiCaiConsole
{
    public class TwoDogsJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string k = dataMap.GetString("key");//获取参数(可根据传递的类型使用GetInt、GetFloat、GetString.....)
            Console.WriteLine($"成功接收：{k}");
            return Task.Run(() => Process());
        }

        /// <summary>
        /// 主要执行逻辑
        /// </summary>
        public void Process()
        {
            var football = new FootballMatchBLL();
            football.SysnWinOrLose();
            football.SysnTotalGoals();
            football.SysnMatchScore();
            football.SysnHalfCourtNegative();
            Console.WriteLine("二狗子过来吃屎了!");
        }
    }


    
}
