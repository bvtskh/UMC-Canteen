namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(20)]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }

        public int Type { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(200)]
        public string LimitedAccess { get; set; }
    }
}
