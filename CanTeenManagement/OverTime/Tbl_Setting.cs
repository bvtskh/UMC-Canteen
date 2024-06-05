namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Setting
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string ReasonOverTime { get; set; }
    }
}
