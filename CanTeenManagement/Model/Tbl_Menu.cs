namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Menu
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MainDishes1 { get; set; }

        [StringLength(50)]
        public string MainDishes2 { get; set; }

        [StringLength(50)]
        public string SideDishes { get; set; }

        [StringLength(50)]
        public string Vegetables { get; set; }

        [StringLength(50)]
        public string Soup { get; set; }

        [StringLength(50)]
        public string Pickles { get; set; }

        [StringLength(50)]
        public string Dessert1 { get; set; }

        [StringLength(50)]
        public string Dessert2 { get; set; }

        [StringLength(50)]
        public string Improve { get; set; }

        [StringLength(50)]
        public string PregnantFood { get; set; }

        [StringLength(50)]
        public string SideMeal1 { get; set; }

        [StringLength(50)]
        public string SideMeal2 { get; set; }

        [StringLength(50)]
        public string SideMeal3 { get; set; }

        [StringLength(50)]
        public string SideMeal4 { get; set; }

        [StringLength(50)]
        public string SideMeal5 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int MenuType { get; set; }

        public virtual Tbl_Dish Tbl_Dish { get; set; }

        public virtual Tbl_Dish Tbl_Dish1 { get; set; }

        public virtual Tbl_Dish Tbl_Dish2 { get; set; }

        public virtual Tbl_Dish Tbl_Dish3 { get; set; }

        public virtual Tbl_Dish Tbl_Dish4 { get; set; }

        public virtual Tbl_Dish Tbl_Dish5 { get; set; }

        public virtual Tbl_Dish Tbl_Dish6 { get; set; }

        public virtual Tbl_Dish Tbl_Dish7 { get; set; }

        public virtual Tbl_Dish Tbl_Dish8 { get; set; }

        public virtual Tbl_Dish Tbl_Dish9 { get; set; }

        public virtual Tbl_Dish Tbl_Dish10 { get; set; }

        public virtual Tbl_Dish Tbl_Dish11 { get; set; }

        public virtual Tbl_Dish Tbl_Dish12 { get; set; }

        public virtual Tbl_Dish Tbl_Dish13 { get; set; }
    }
}
