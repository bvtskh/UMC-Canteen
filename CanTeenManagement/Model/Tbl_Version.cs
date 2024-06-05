namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Version
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Version { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
    }
}
