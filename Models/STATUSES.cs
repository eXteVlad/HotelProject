namespace Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXTE.STATUSES")]
    public partial class STATUSES
    {
        [Key]
        [Column(Order = 0)]
        public decimal ID_CLIENT { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal ID_SERVICE { get; set; }

        public decimal? TIME_SERVICE { get; set; }

        public virtual CLIENTS CLIENTS { get; set; }

        public virtual SERVICES SERVICES { get; set; }
    }
}
