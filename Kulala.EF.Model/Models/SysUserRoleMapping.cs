namespace Kulala.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysUserRoleMapping")]
    public partial class SysUserRoleMapping
    {
        public int Id { get; set; }

        public int SysUserId { get; set; }

        public int SysRoleId { get; set; }

        public virtual User SysUser { get; set; }
        public virtual SysRole SysRole { get; set; }
   
    }
}
