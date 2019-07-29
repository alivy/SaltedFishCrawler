namespace Data.Model.DBModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext() : base("name=JieCaiDB")
        {
        }
        /// <summary>
        /// ´´½¨DBContext
        /// </summary>
        /// <returns></returns>
        public static DBContext CreateContext()
        {
            //DBContext db = CallContext.GetData("DbContext") as DBContext;
            //if (db == null)
            //{
            //    db = new DBContext();
            //    CallContext.SetData("DbContext", db);
            //}
            //return db;
            return new DBContext();
        }
        public virtual DbSet<JieCaiTable> JieCaiTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
