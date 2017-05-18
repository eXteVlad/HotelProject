namespace Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXTE.CLIENTS")]
    public partial class CLIENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTS()
        {
            STATUSES = new HashSet<STATUSES>();
            RESERVATION = new HashSet<RESERVATION>();
        }

        [Key]
        public decimal ID_CLIENT { get; set; }

        [StringLength(20)]
        public string FAM { get; set; }

        [StringLength(20)]
        public string IM { get; set; }

        [StringLength(20)]
        public string OT { get; set; }

        [StringLength(24)]
        public string LOGIN { get; set; }

        [StringLength(20)]
        public string PASSWORD { get; set; }

        public decimal DOC_TYPE { get; set; }

        [StringLength(20)]
        public string SERIAL_DOC { get; set; }

        [Required]
        [StringLength(7)]
        public string GENDER { get; set; }

        public decimal? SALE { get; set; }

        public decimal? BEGIN_PRICE { get; set; }

        public decimal? TOTAL_PRICE { get; set; }

        public decimal? NUMBER_DOC { get; set; }

        public decimal ADMIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATUSES> STATUSES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATION> RESERVATION { get; set; }
    }
}
