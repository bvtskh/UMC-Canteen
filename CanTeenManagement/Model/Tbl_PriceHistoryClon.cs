namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_PriceHistoryClon
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public int? Price { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }

        public int? mYear { get; set; }

        public int? mMonth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApproveDate { get; set; }
    }
}

