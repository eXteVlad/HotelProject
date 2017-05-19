namespace Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXTE.RESERVATION")]
    public partial class RESERVATION
    {
        [Key]
        [Column(Order = 0)]
        public decimal ID_ROOM { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal ID_CLIENT { get; set; }

        [Key]
        [Column(Order = 2)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_IN { get; set; }

        [Key]
        [Column(Order = 3)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_OUT { get; set; }
    }
}
