using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FishTest
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch sw = new Stopwatch();
            List<Custom> customs = new List<Custom>();
            for (int i = 0; i < 2000000; i++)
            {
                customs.Add(new Custom() { Name = "Jack", Age = 21, Address = "NewYork" });
                customs.Add(new Custom() { Name = "Jime", Age = 26, Address = "China" });
                customs.Add(new Custom() { Name = "Tina", Age = 29, Address = "ShangHai" });
                customs.Add(new Custom() { Name = "Luo", Age = 30, Address = "Beijing" });
                customs.Add(new Custom() { Name = "Wang", Age = 60, Address = "Guangdong" });
                customs.Add(new Custom() { Name = "Feng", Age = 25, Address = "YunNan" });
            }

            sw.Start();
            var result = customs.Where<Custom>(c => c.Age > 26).ToList();
            sw.Stop();
            Console.WriteLine("Linq time is {0}.", sw.ElapsedMilliseconds);

            sw.Restart();
            sw.Start();
            var result2 = customs.AsParallel().Where<Custom>(c => c.Age > 26).ToList();
            sw.Stop();
            Console.WriteLine("Parallel Linq time is {0}.", sw.ElapsedMilliseconds);
        }
    }

    public class Custom
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
