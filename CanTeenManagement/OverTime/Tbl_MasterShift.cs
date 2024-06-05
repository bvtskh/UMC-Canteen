namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_MasterShift
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string ShiftCode { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public int? WorkMinutes { get; set; }

        public TimeSpan? ApplyOverTime { get; set; }

        [StringLength(10)]
        public string Shift { get; set; }
    }
}
