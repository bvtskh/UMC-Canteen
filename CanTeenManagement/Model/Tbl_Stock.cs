namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Stock
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? Stock { get; set; }

        public double? Input { get; set; }

        public double? Output { get; set; }
    }
}
