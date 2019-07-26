using System;
using BLL;
using Data.Model.DBModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FishTest
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new BaseBLL<JieCaiTable>().AddEntity(new JieCaiTable
            {
                Name = "三狗子"
            });

            var tt = new JieCaiTableBLL().QueryTset();

        }
    }
}
