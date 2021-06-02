namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_detail
    {
        [Key]
        public int Order_detail_id { get; set; }

        public int? Order_id { get; set; }

        public int? Phones_id { get; set; }

        public int? Price { get; set; }

        public int? Sale_quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Phones Phones { get; set; }
    }
}
