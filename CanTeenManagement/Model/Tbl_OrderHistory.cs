namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OrderHistory
    {
        public int Id { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? OrderForDate { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [StringLength(50)]
        public string AccountOrder { get; set; }

        public double? TotalPayment { get; set; }

        [StringLength(30)]
        public string HistoryOrderCode { get; set; }
    }
}
