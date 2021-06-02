namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phones()
        {
            Comment = new HashSet<Comment>();
            Order_detail = new HashSet<Order_detail>();
            Sale_phones = new HashSet<Sale_phones>();
        }

        [Key]
        public int Phones_id { get; set; }

        public int? Category_id { get; set; }

        [StringLength(255)]
        public string Name_phone { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Meta_title { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public int? Price { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Screen { get; set; }

        [StringLength(255)]
        public string Operating_system { get; set; }

        [StringLength(255)]
        public string Rear_camera { get; set; }

        [StringLength(255)]
        public string Front_camera { get; set; }

        [StringLength(255)]
        public string Chip { get; set; }

        [StringLength(255)]
        public string Ram { get; set; }

        [StringLength(255)]
        public string Internal_memory { get; set; }

        [StringLength(255)]
        public string Sim { get; set; }

        [StringLength(255)]
        public string Pin { get; set; }

        [StringLength(255)]
        public string Charger { get; set; }

        public int? Promotion_price { get; set; }

        public DateTime? Start_promotion { get; set; }

        public DateTime? End_promotion { get; set; }

        public DateTime? Create_date { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_detail> Order_detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale_phones> Sale_phones { get; set; }
    }
}
