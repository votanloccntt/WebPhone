namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Phones = new HashSet<Phones>();
        }

        [Key]
        public int Category_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên danh mục")]
        public string Category_name { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Metta_title { get; set; }
        [Display(Name = "Danh mục con")]
        public int? Parent_id { get; set; }
        [Display(Name = "Lớp màn hình")]
        public int? Display_order { get; set; }

        [StringLength(255)]
        [Display(Name = "Tiêu đề SEO")]
        public string Seo_title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
