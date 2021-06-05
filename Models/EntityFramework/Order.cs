namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_detail = new HashSet<Order_detail>();
        }

        [Key]
        public int Order_id { get; set; }

        public int? Customer_id { get; set; }

        public int? Status_id { get; set; }

        public int? Deliverer_id { get; set; }

        public DateTime? Create_date { get; set; }

        public int? Total_price { get; set; }

        [StringLength(255)]
        public string Delivery_address { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Deliverer Deliverer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_detail> Order_detail { get; set; }

        public virtual Status Status { get; set; }
    }
}
