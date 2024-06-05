namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_RestrictOT
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        [StringLength(100)]
        public string Reason { get; set; }

        public DateTime? DateLimit { get; set; }
    }
}
