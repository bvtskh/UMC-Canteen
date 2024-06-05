namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Quantitative
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DishCode { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? Quantitative { get; set; }

        public virtual Tbl_Dish Tbl_Dish { get; set; }

        public virtual Tbl_Ingredient Tbl_Ingredient { get; set; }
    }
}
