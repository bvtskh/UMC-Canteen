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

        public DateTime? TimeUpdate { get; set; }

        public int? SupplierId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApprovalDate { get; set; }

        [StringLength(100)]
        public string Comment { get; set; }

        public int? PriceMain { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }
    }
}

