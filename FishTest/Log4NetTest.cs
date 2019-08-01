using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Help;

namespace FishTest
{
    [TestClass]
    public class Log4NetTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Log.Write(LogLevel.Info, "Info 日志写入测试");
            Log.Write(LogLevel.Error, "Error 日志写入测试");
            Log.Write(LogLevel.Warn, "Warn 日志写入测试");
            Log.Write(LogLevel.Debug, "Debug 日志写入测试");
            Log.Write(LogLevel.Fatal, "Fatal 日志写入测试");
        }

        /// <summary>
        /// 多线程异步写入测试
        /// </summary>
        [TestMethod]
        public void Action_LogWrite()
        {
            for (int i = 0; i < 100; i++)
            {
                var task = Task.Run(() => Log.Write(LogLevel.Info, "Info 日志写入测试" + i));
            }
            Task.WaitAll();
            Log.Write(LogLevel.Info, "打印完成");
        }
    }
}
