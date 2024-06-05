namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_PriceUpdateChange
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string IngredientCode { get; set; }

        public int? OldPrice { get; set; }

        public int? NewPrice { get; set; }

        public DateTime? UpdateTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApproveTime { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string HostName { get; set; }

        [StringLength(10)]
        public string SupplierCode { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }
    }
}
