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
        [Display(Name = "Tên điện thoại")]
        public string Name_phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã điện thoại")]
        public string Code { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Meta_title { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [Display(Name = "Giá")]
        public int? Price { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [StringLength(255)]
        [Display(Name = "Màn hình")]
        public string Screen { get; set; }

        [StringLength(255)]
        [Display(Name = "Hệ điều hành")]
        public string Operating_system { get; set; }

        [StringLength(255)]
        [Display(Name = "Cam sau")]
        public string Rear_camera { get; set; }

        [StringLength(255)]
        [Display(Name = "Cam trước")]
        public string Front_camera { get; set; }

        [StringLength(255)]
        [Display(Name = "Bộ xử lý")]
        public string Chip { get; set; }

        [StringLength(255)]
        [Display(Name = "Ram")]
        public string Ram { get; set; }

        [StringLength(255)]
        [Display(Name = "Bộ nhớ trong")]
        public string Internal_memory { get; set; }

        [StringLength(255)]
        [Display(Name = "Sim")]
        public string Sim { get; set; }

        [StringLength(255)]
        [Display(Name = "Pin")]
        public string Pin { get; set; }

        [StringLength(255)]
        [Display(Name = "Sạc")]
        public string Charger { get; set; }
        [Display(Name = "Giá khuyến mãi")]

        public int? Promotion_price { get; set; }
        [Display(Name = "Bắt đầu khuyến mãi")]
        public DateTime? Start_promotion { get; set; }
        [Display(Name = "Kết thúc khuyến mãi")]
        public DateTime? End_promotion { get; set; }
        [Display(Name = "Ngày tạo sản phẩm")]
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
