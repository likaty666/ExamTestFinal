namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Genre")]
    public partial class Genre
    {
        [Key]
        public int genre_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }
    }
}
