using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiCaiConsole
{
    /// <summary>
    /// 执行计划
    /// </summary>
    public class ExecutePlan
    {
        private static readonly string tiggerName = "TestJobTrigger";
        private static readonly string gropName = "TestJobTriggerGrop";
        private static readonly string jobName = "TestJob";
        //从工厂中获取一个调度器实例化
        private static IScheduler scheduler = null;

        /// <summary>
        /// 按时间启动
        /// </summary>
        public static async void StartTime<T>(Action<SimpleScheduleBuilder> action) where T : IJob
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            //job 执行任务
            IJobDetail job = JobBuilder.Create<T>()
                                       .WithIdentity(jobName, gropName)  //使用具有给定名称和组的quartz.job键来标识作业详细信息.
                                       .UsingJobData("key", "一陀屎")   // 传递参数 在Execute方法中获取（以什么类型值传入，取值就用相应的类型方法取值）
                                       .Build();
            try
            {
                //用于监听事件执行
                var jobListener = new TwoDogsJobListener();
                scheduler.ListenerManager.AddJobListener(jobListener, GroupMatcher<JobKey>.AnyGroup());
                //trigger 触发器
                ITrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().WithSimpleSchedule(action).Build();
                //开始调度
                await scheduler.ScheduleJob(job, trigger);
                // Start启动线程调度
                await scheduler.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await scheduler.Shutdown();
            }
        }


        /// <summary>
        /// 清除任务和触发器
        /// </summary>
        private static void ClearJobTrigger()
        {
            TriggerKey triggerKey = new TriggerKey(tiggerName, gropName);
            JobKey jobKey = new JobKey(jobName, gropName);
            if (scheduler != null)
            {
                scheduler.PauseTrigger(triggerKey);
                scheduler.UnscheduleJob(triggerKey);
                scheduler.DeleteJob(jobKey);
                scheduler.Shutdown();// 关闭
            }
        }



    }
}
