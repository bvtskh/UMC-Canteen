namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Priority
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string SupplierCode { get; set; }
       
        public int? DAY { get; set; }
    }
}
