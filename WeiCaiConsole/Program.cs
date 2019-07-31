using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiCaiConsole
{


    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("***************任务启动****************");
            demo1();
            Console.WriteLine("***************任务结束****************");
            Console.Read();
        }

        /// <summary>
        /// Quartz按 时 分 秒 执行
        /// </summary>
        public static void demo1()
        {
            var simpleSchedule = SimpleScheduleBuilder.Create();
            Action<SimpleScheduleBuilder> action = (x) =>
            {
                //按小时 永远执行
                //x.WithIntervalInHours(1).RepeatForever();
                ////按分钟执行 n+1次
                //x.WithIntervalInMinutes(1).WithRepeatCount(50);
                //按分钟执行 永远执行
                x.WithIntervalInSeconds(1).RepeatForever();
            };
            ExecutePlan.StartTime<TwoDogsJob>(action);
        }


    }
}
