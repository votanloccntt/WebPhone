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
        public string Category_name { get; set; }

        [StringLength(50)]
        public string Metta_title { get; set; }

        public int? Parent_id { get; set; }

        public int? Display_order { get; set; }

        [StringLength(255)]
        public string Seo_title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
