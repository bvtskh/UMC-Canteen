namespace CanTeenManagement.OverTime
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_ShiftWorking
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        [StringLength(6)]
        public string Day1 { get; set; }

        [StringLength(6)]
        public string Day2 { get; set; }

        [StringLength(6)]
        public string Day3 { get; set; }

        [StringLength(6)]
        public string Day4 { get; set; }

        [StringLength(6)]
        public string Day5 { get; set; }

        [StringLength(6)]
        public string Day6 { get; set; }

        [StringLength(6)]
        public string Day7 { get; set; }

        [StringLength(6)]
        public string Day8 { get; set; }

        [StringLength(6)]
        public string Day9 { get; set; }

        [StringLength(6)]
        public string Day10 { get; set; }

        [StringLength(6)]
        public string Day11 { get; set; }

        [StringLength(6)]
        public string Day12 { get; set; }

        [StringLength(6)]
        public string Day13 { get; set; }

        [StringLength(6)]
        public string Day14 { get; set; }

        [StringLength(6)]
        public string Day15 { get; set; }

        [StringLength(6)]
        public string Day16 { get; set; }

        [StringLength(6)]
        public string Day17 { get; set; }

        [StringLength(6)]
        public string Day18 { get; set; }

        [StringLength(6)]
        public string Day19 { get; set; }

        [StringLength(6)]
        public string Day20 { get; set; }

        [StringLength(6)]
        public string Day21 { get; set; }

        [StringLength(6)]
        public string Day22 { get; set; }

        [StringLength(6)]
        public string Day23 { get; set; }

        [StringLength(6)]
        public string Day24 { get; set; }

        [StringLength(6)]
        public string Day25 { get; set; }

        [StringLength(6)]
        public string Day26 { get; set; }

        [StringLength(6)]
        public string Day27 { get; set; }

        [StringLength(6)]
        public string Day28 { get; set; }

        [StringLength(6)]
        public string Day29 { get; set; }

        [StringLength(6)]
        public string Day30 { get; set; }

        [StringLength(6)]
        public string Day31 { get; set; }

        [StringLength(300)]
        public string AllDay { get; set; }
    }
}
