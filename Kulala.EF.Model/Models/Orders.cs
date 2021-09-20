namespace Kulala.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class Orders
    {
        [Key]
        public double ORD_NUM { get; set; }

        public double ORD_AMOUNT { get; set; }

        public double ADVANCE_AMOUNT { get; set; }

        [Column(TypeName = "date")]
        public DateTime ORD_DATE { get; set; }

        [Required]
        [StringLength(6)]
        public string CUST_CODE { get; set; }

        [Required]
        [StringLength(6)]
        public string AGENT_CODE { get; set; }

        [Required]
        [StringLength(60)]
        public string ORD_DESCRIPTION { get; set; }

        public virtual Agents AGENTS { get; set; }

        public virtual Customer CUSTOMER { get; set; }
    }
}
