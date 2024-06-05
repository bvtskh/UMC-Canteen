namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_FoodPortion
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOrder { get; set; }

        public int? DishMain1Number { get; set; }

        public int? DishMain2Number { get; set; }

        public int? DishSideNumber { get; set; }

        public int? VegetableNumber { get; set; }

        public int? SoupNumber { get; set; }

        public int? PicklesNumber { get; set; }

        public int? Dessert1Number { get; set; }

        public int? Dessert2Number { get; set; }

        public int? Improve1Number { get; set; }

        public int? GourdFoodNumber { get; set; }

        public int? SideMeal1Number { get; set; }

        public int? SideMeal2Number { get; set; }

        public int? SideMeal3Number { get; set; }

        public int? SideMeal4Number { get; set; }

        public int? SideMeal5Number { get; set; }

        public int? OrderHistoryId { get; set; }
    }
}
