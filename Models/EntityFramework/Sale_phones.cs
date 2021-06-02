namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale_phones
    {
        [Key]
        public int Sale_phones_id { get; set; }

        public int? Phones_id { get; set; }

        public int? Quantity { get; set; }

        public DateTime? Create_date { get; set; }

        public virtual Phones Phones { get; set; }
    }
}
