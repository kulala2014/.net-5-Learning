namespace Kulala.Learning.CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AGENTS()
        {
            CUSTOMER = new HashSet<CUSTOMER>();
            ORDERS = new HashSet<ORDERS>();
        }

        [Key]
        [StringLength(6)]
        public string AGENT_CODE { get; set; }

        [StringLength(40)]
        public string AGENT_NAME { get; set; }

        [StringLength(35)]
        public string WORKING_AREA { get; set; }

        [StringLength(10)]
        public string COMMISSION { get; set; }

        [StringLength(15)]
        public string PHONE_NO { get; set; }

        [StringLength(25)]
        public string COUNTRY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERS> ORDERS { get; set; }
    }
}
