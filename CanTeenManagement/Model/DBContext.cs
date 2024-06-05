using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CanTeenManagement.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("data source=172.28.10.28;initial catalog=CanteenManagement;persist security info=True;user id=sa;password=umc@123;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_ChangeOrder> Tbl_ChangeOrder { get; set; }
        public virtual DbSet<Tbl_Dish> Tbl_Dish { get; set; }
        public virtual DbSet<Tbl_FoodPortion> Tbl_FoodPortion { get; set; }
        public virtual DbSet<Tbl_HistoryInOut> Tbl_HistoryInOut { get; set; }
        public virtual DbSet<Tbl_HistoryPrice> Tbl_HistoryPrice { get; set; }
        public virtual DbSet<Tbl_Ingredient> Tbl_Ingredient { get; set; }
        public virtual DbSet<Tbl_Menu> Tbl_Menu { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_OrderHistory> Tbl_OrderHistory { get; set; }
        public virtual DbSet<Tbl_PreOrder> Tbl_PreOrder { get; set; }
        public virtual DbSet<Tbl_PriceUpdateChange> Tbl_PriceUpdateChange { get; set; }
        public virtual DbSet<Tbl_Quantitative> Tbl_Quantitative { get; set; }
        public virtual DbSet<Tbl_Stock> Tbl_Stock { get; set; }
        public virtual DbSet<Tbl_Supplier> Tbl_Supplier { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_Version> Tbl_Version { get; set; }
        public virtual DbSet<Tbl_PriceHistoryClon> Tbl_HistoryPriceClon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu)
                .WithOptional(e => e.Tbl_Dish)
                .HasForeignKey(e => e.Dessert1);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu1)
                .WithOptional(e => e.Tbl_Dish1)
                .HasForeignKey(e => e.Dessert2);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu2)
                .WithOptional(e => e.Tbl_Dish2)
                .HasForeignKey(e => e.PregnantFood);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu3)
                .WithOptional(e => e.Tbl_Dish3)
                .HasForeignKey(e => e.Improve);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu4)
                .WithOptional(e => e.Tbl_Dish4)
                .HasForeignKey(e => e.MainDishes1);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu5)
                .WithOptional(e => e.Tbl_Dish5)
                .HasForeignKey(e => e.MainDishes2);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu6)
                .WithOptional(e => e.Tbl_Dish6)
                .HasForeignKey(e => e.Pickles);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu7)
                .WithOptional(e => e.Tbl_Dish7)
                .HasForeignKey(e => e.SideDishes);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu8)
                .WithOptional(e => e.Tbl_Dish8)
                .HasForeignKey(e => e.SideMeal1);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu9)
                .WithOptional(e => e.Tbl_Dish9)
                .HasForeignKey(e => e.SideMeal2);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu10)
                .WithOptional(e => e.Tbl_Dish10)
                .HasForeignKey(e => e.SideMeal3);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu11)
                .WithOptional(e => e.Tbl_Dish11)
                .HasForeignKey(e => e.SideMeal4);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu12)
                .WithOptional(e => e.Tbl_Dish12)
                .HasForeignKey(e => e.Soup);

            modelBuilder.Entity<Tbl_Dish>()
                .HasMany(e => e.Tbl_Menu13)
                .WithOptional(e => e.Tbl_Dish13)
                .HasForeignKey(e => e.Vegetables);

            modelBuilder.Entity<Tbl_Ingredient>()
                .HasMany(e => e.Tbl_HistoryPrice)
                .WithRequired(e => e.Tbl_Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Ingredient>()
                .HasMany(e => e.Tbl_Order)
                .WithRequired(e => e.Tbl_Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Ingredient>()
                .HasMany(e => e.Tbl_PreOrder)
                .WithRequired(e => e.Tbl_Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Ingredient>()
                .HasMany(e => e.Tbl_Quantitative)
                .WithRequired(e => e.Tbl_Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.PassWord)
                .IsFixedLength();
        }
    }
}
