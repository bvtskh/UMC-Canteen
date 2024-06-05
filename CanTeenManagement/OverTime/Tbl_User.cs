namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_User
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string UserCode { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Dept { get; set; }

        [StringLength(10)]
        public string Role { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string TypeUser { get; set; }
    }
}
