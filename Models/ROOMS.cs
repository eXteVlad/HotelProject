namespace Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXTE.ROOMS")]
    public partial class ROOMS
    {
        [Key]
        public decimal ID_ROOM { get; set; }

        public decimal NUM_ROOM { get; set; }

        public decimal? PLACES { get; set; }

        [StringLength(8)]
        public string CATEGORY { get; set; }

        public decimal? PRICE { get; set; }

    }
}
