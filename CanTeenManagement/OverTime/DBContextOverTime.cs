namespace CanTeenManagement.OverTime
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContextOverTime : DbContext
    {
        public DBContextOverTime()
            : base("name=DBContextOverTime")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_DailyOverTime> Tbl_DailyOverTime { get; set; }
        public virtual DbSet<Tbl_OTBeforeShift> Tbl_OTBeforeShift { get; set; }
        public virtual DbSet<Tbl_ShiftWorking> Tbl_ShiftWorking { get; set; }
        public virtual DbSet<Tbl_SummaryOverTime> Tbl_SummaryOverTime { get; set; }
        public virtual DbSet<Tbl_Approve> Tbl_Approve { get; set; }
        public virtual DbSet<Tbl_BudgetOT> Tbl_BudgetOT { get; set; }
        public virtual DbSet<Tbl_HistoryUpdateOT> Tbl_HistoryUpdateOT { get; set; }
        public virtual DbSet<Tbl_MasterShift> Tbl_MasterShift { get; set; }
        public virtual DbSet<Tbl_RestrictOT> Tbl_RestrictOT { get; set; }
        public virtual DbSet<Tbl_Setting> Tbl_Setting { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_Version> Tbl_Version { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_DailyOverTime>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DailyOverTime>()
                .Property(e => e.CaLV)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_DailyOverTime>()
                .Property(e => e.UserRegister)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_OTBeforeShift>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day1)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day2)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day3)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day4)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day5)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day6)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day7)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day8)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day9)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day10)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day11)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day12)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day13)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day14)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day15)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day16)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day17)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day18)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day19)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day20)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day21)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day22)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day23)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day24)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day25)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day26)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day27)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day28)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day29)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day30)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.Day31)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_ShiftWorking>()
                .Property(e => e.AllDay)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_SummaryOverTime>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Approve>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Approve>()
                .Property(e => e.EmailApprove)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Approve>()
                .Property(e => e.Approve)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_BudgetOT>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_HistoryUpdateOT>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_HistoryUpdateOT>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_HistoryUpdateOT>()
                .Property(e => e.UserUpdate)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MasterShift>()
                .Property(e => e.ShiftCode)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_MasterShift>()
                .Property(e => e.Shift)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_RestrictOT>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_RestrictOT>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.TypeUser)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Version>()
                .Property(e => e.Version)
                .IsUnicode(false);
        }
    }
}
