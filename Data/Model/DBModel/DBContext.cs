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

        public virtual DbSet<tblFootballMatch> tblFootballMatch { get; set; }

        public virtual DbSet<tblWinOrLosehad> tblWinOrLosehad { get; set; }
        public virtual DbSet<tblWinOrLosehhad> tblWinOrLosehhad { get; set; }

        public virtual DbSet<tblTotalGoalsttg> tblTotalGoalsttg { get; set; }

        public virtual DbSet<tblMatchScorecrs> tblMatchScorecrs { get; set; }

        public virtual DbSet<tblHalfCourtNegativehafu> tblHalfCourtNegativehafu { get; set; }

        public virtual DbSet<UserInfo> userInfo { get; set; }

        public virtual DbSet<Q_Pulse> puls { get; set; }

        public virtual DbSet<PersonalWallet> personalWallet { get; set; }
        public virtual DbSet<Consumptiondetails> consumptiondetails { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
