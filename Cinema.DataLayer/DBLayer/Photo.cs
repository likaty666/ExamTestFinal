namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        [Key]
        public int photo_id { get; set; }

        public int? film_id { get; set; }

        [Required]
        [StringLength(150)]
        public string pathPhoto { get; set; }

        public bool? isMain { get; set; }

        public bool? catalog { get; set; }

        public virtual Film Film { get; set; }
    }
}
