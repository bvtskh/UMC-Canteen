namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Version
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Version { get; set; }

        public DateTime? DateCreate { get; set; }

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(300)]
        public string Path { get; set; }
    }
}
