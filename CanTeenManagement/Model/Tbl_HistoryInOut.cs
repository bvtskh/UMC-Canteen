namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_HistoryInOut
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? Quantity { get; set; }

        public int? HistoryPriceId { get; set; }

        public int? PriceTotal { get; set; }

        public double? StockBeforInOut { get; set; }

        public double? StockAfterInOut { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? DateTimeInOut { get; set; }

        [StringLength(50)]
        public string UserAction { get; set; }

        [StringLength(50)]
        public string BillCode { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }
    }
}
