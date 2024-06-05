namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Ingredient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Ingredient()
        {
            Tbl_HistoryPrice = new HashSet<Tbl_HistoryPrice>();
            Tbl_Order = new HashSet<Tbl_Order>();
            Tbl_PreOrder = new HashSet<Tbl_PreOrder>();
            Tbl_Quantitative = new HashSet<Tbl_Quantitative>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string IngredientCode { get; set; }

        [StringLength(100)]
        public string IngredientName { get; set; }

        [StringLength(100)]
        public string Spec { get; set; }

        [StringLength(30)]
        public string Unit { get; set; }

        public double? SafeStock { get; set; }

        public int IndexNumber { get; set; }

        public int? IsAlwayOutStock { get; set; }

        public int? SupplierPriorityId { get; set; }

        public int? IsAlwayBuy { get; set; }

        [StringLength(10)]
        public string SupplierPriorityCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_HistoryPrice> Tbl_HistoryPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Order> Tbl_Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PreOrder> Tbl_PreOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Quantitative> Tbl_Quantitative { get; set; }
    }
}
