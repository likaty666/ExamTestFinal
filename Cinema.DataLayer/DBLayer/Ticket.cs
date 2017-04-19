namespace Cinema.DataLayer.DBLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [Key]
        public int ticket_id { get; set; }

        public int film_id { get; set; }

        public int hall_id { get; set; }

        public decimal price { get; set; }

        public int ses_id { get; set; }

        public int seat { get; set; }

        [StringLength(256)]
        public string user_id { get; set; }

        public virtual Film Film { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual SessionDate SessionDate { get; set; }
    }
}
