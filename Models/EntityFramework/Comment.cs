namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int Comment_id { get; set; }

        public int? Phone_id { get; set; }

        [StringLength(25)]
        public string Full_name { get; set; }

        public DateTime? Comment_time { get; set; }

        [StringLength(255)]
        public string Comment_content { get; set; }

        [StringLength(25)]
        public string Phone_number { get; set; }

        public virtual Phones Phones { get; set; }
    }
}
