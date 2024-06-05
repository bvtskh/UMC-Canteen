namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_PreOrder
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? PreOrder { get; set; }

        public DateTime? PreDateOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOrder { get; set; }

        public int? OrderHistoryId { get; set; }

        public virtual Tbl_Ingredient Tbl_Ingredient { get; set; }
    }
}
