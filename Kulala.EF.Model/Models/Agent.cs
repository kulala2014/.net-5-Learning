namespace Kulala.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGENTS")]
    public partial class Agents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agents()
        {
            CUSTOMER = new HashSet<Customer>();
            ORDERS = new HashSet<Orders>();
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
        public virtual ICollection<Customer> CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> ORDERS { get; set; }
    }
}
