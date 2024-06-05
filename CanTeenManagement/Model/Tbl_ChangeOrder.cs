namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ChangeOrder
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? OriginalOrder { get; set; }

        public double? ActualOrder { get; set; }

        public int? OrderHistoryId { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }
    }
}
