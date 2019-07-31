using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeiCaiConsole
{
    /// <summary>
    /// 
    /// </summary>
    public class TwoDogsJobListener : IJobListener
    {
        public string Name => "二狗子";

        /// <summary>
        /// 当Quartz.iJob细节即将执行时由Quartz.isscheduler调用
        ///（发生了相关的quartz.itrigger），但quartz.itrigger的听众否决了这是执行。
        /// </summary>
        /// <returns></returns>
        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                Console.WriteLine("*******************************");
                Console.WriteLine($"{Name}吃屎");
            });
        }

        /// <summary>
        ///  在即将执行quartz.i作业详细信息时由quartz.isscheduler调用
        ///（出现了一种相关的石英玻璃）。
        /// 如果Quartz.Itrigger侦听器拒绝执行作业，则不会调用此方法。
        /// </summary>
        /// <returns></returns>
        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                Console.WriteLine("*******************************");
                Console.WriteLine($"{Name}吃屎前准备就绪");
            });

        }

        /// <summary>
        ///在执行quartz.i作业详细信息后由quartz.isscheduler调用，
        ///并用于关联的quartz.spi.ioperable触发器的quartz.spi.ioperable触发器。已触发（quartz.iCalendar）
        ///已调用方法。
        /// </summary>
        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{Name}吃完一坨屎了");
                Console.WriteLine("*******************************");
            });
        }
    }
}
