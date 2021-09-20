namespace Kulala.Learning.CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            ORDERS = new HashSet<ORDERS>();
        }

        [Key]
        [StringLength(6)]
        public string CUST_CODE { get; set; }

        [Required]
        [StringLength(40)]
        public string CUST_NAME { get; set; }

        [StringLength(35)]
        public string CUST_CITY { get; set; }

        [Required]
        [StringLength(35)]
        public string WORKING_AREA { get; set; }

        [Required]
        [StringLength(20)]
        public string CUST_COUNTRY { get; set; }

        public double? GRADE { get; set; }

        public double OPENING_AMT { get; set; }

        public double RECEIVE_AMT { get; set; }

        public double PAYMENT_AMT { get; set; }

        public double OUTSTANDING_AMT { get; set; }

        [Required]
        [StringLength(17)]
        public string PHONE_NO { get; set; }

        [Required]
        [StringLength(6)]
        public string AGENT_CODE { get; set; }

        public virtual AGENTS AGENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERS> ORDERS { get; set; }
    }
}
