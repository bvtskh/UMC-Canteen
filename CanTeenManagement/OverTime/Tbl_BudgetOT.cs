namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_BudgetOT
    {
        public int Id { get; set; }

        public DateTime? MonthBudget { get; set; }

        [StringLength(20)]
        public string Dept { get; set; }

        [StringLength(50)]
        public string Customer { get; set; }

        public double? BudgetOT { get; set; }

        public double? NumberHuman { get; set; }
    }
}
