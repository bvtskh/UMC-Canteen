namespace CanTeenManagement.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Dish()
        {
            Tbl_Menu = new HashSet<Tbl_Menu>();
            Tbl_Menu1 = new HashSet<Tbl_Menu>();
            Tbl_Menu2 = new HashSet<Tbl_Menu>();
            Tbl_Menu3 = new HashSet<Tbl_Menu>();
            Tbl_Menu4 = new HashSet<Tbl_Menu>();
            Tbl_Menu5 = new HashSet<Tbl_Menu>();
            Tbl_Menu6 = new HashSet<Tbl_Menu>();
            Tbl_Menu7 = new HashSet<Tbl_Menu>();
            Tbl_Menu8 = new HashSet<Tbl_Menu>();
            Tbl_Menu9 = new HashSet<Tbl_Menu>();
            Tbl_Menu10 = new HashSet<Tbl_Menu>();
            Tbl_Menu11 = new HashSet<Tbl_Menu>();
            Tbl_Menu12 = new HashSet<Tbl_Menu>();
            Tbl_Menu13 = new HashSet<Tbl_Menu>();
            Tbl_Quantitative = new HashSet<Tbl_Quantitative>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string DishCode { get; set; }

        [StringLength(100)]
        public string Dish { get; set; }

        public int? Number { get; set; }

        [StringLength(50)]
        public string IsPreOrderDish { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu8 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu9 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu11 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu12 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Menu> Tbl_Menu13 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Quantitative> Tbl_Quantitative { get; set; }
    }
}
