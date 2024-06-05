namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_DailyOverTime
    {
        public int Id { get; set; }

        public DateTime? DateOverTime { get; set; }

        [StringLength(15)]
        public string Code { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(10)]
        public string CaLV { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public double? OTDayShift { get; set; }

        public double? AdjustOTDayShift { get; set; }

        public double? OTNightShift { get; set; }

        public double? AdjustOTNightShift { get; set; }

        public double? TimeOTFinger { get; set; }

        public double? TimeRegisted { get; set; }

        public double? TimeOTPreshift { get; set; }

        public double? TotalOT { get; set; }

        public double? TimeOTDept { get; set; }

        public double? Balance { get; set; }

        [StringLength(150)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string Reason { get; set; }

        [StringLength(30)]
        public string Approve { get; set; }

        [StringLength(10)]
        public string UserRegister { get; set; }
    }
}
