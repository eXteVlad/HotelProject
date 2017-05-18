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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOMS()
        {
            RESERVATION = new HashSet<RESERVATION>();
        }

        [Key]
        public decimal ID_ROOM { get; set; }

        public decimal NUM_ROOM { get; set; }

        public decimal? PLACES { get; set; }

        [StringLength(8)]
        public string CATEGORY { get; set; }

        public decimal? PRICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATION> RESERVATION { get; set; }
    }
}
