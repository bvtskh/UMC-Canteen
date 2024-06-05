namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_OTBeforeShift
    {
        public int Id { get; set; }

        public DateTime? MonthOfYear { get; set; }

        [StringLength(15)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(300)]
        public string RegisOverTime { get; set; }
    }
}
