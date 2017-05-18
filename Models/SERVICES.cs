namespace Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXTE.SERVICES")]
    public partial class SERVICES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICES()
        {
            STATUSES = new HashSet<STATUSES>();
        }

        [Key]
        public decimal ID_SERVICE { get; set; }

        [StringLength(50)]
        public string NAME_SERVICE { get; set; }

        public decimal? PRICE_ONHOUR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATUSES> STATUSES { get; set; }
    }
}
