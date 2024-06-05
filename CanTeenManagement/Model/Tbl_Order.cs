namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Order
    {
        public int Id { get; set; }

        public DateTime? BillCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        public double? ActualOrder { get; set; }

        public double? PlanOrder { get; set; }

        public int? HistoryPriceId { get; set; }

        public int? CurrentApprovePrice { get; set; }

        public int? PriceTotal { get; set; }

        public int? OrderHistoryId { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(500)]
        public string ReMark { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }

        public virtual Tbl_Ingredient Tbl_Ingredient { get; set; }
    }
}
