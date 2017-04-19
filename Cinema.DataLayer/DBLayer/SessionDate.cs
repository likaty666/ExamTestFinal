namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SessionDate")]
    public partial class SessionDate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SessionDate()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int ses_id { get; set; }

        public int film_id { get; set; }

        public int hall_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime sesDate { get; set; }

        public int? timeIsh { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
