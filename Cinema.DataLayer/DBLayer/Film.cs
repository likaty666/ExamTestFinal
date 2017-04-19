namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Photos = new HashSet<Photo>();
            SessionDates = new HashSet<SessionDate>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int film_id { get; set; }

        [Required]
        [StringLength(155)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        public string about { get; set; }

        [Column(TypeName = "text")]
        public string starring { get; set; }

        [StringLength(100)]
        public string director { get; set; }

        [Column(TypeName = "date")]
        public DateTime beginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime endDate { get; set; }

        [StringLength(255)]
        public string trailer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionDate> SessionDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
