namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Approve
    {
        public int Id { get; set; }

        public DateTime? DateOT { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        [StringLength(30)]
        public string EmailApprove { get; set; }

        [StringLength(30)]
        public string Approve { get; set; }
    }
}
