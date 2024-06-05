namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_SummaryOverTime
    {
        public int Id { get; set; }

        public DateTime? MonthOfYear { get; set; }

        [StringLength(15)]
        public string Code { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        public double? MaxOverTime { get; set; }

        public double? PlanOverTime { get; set; }

        public double? TotalOverTime { get; set; }

        [StringLength(200)]
        public string Actual { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}
