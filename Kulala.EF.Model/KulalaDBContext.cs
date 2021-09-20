using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Kulala.EF.Model
{
    public partial class KulalaDBContext : DbContext
    {
        public KulalaDBContext()
            : base("name=KulalaDBContext")
        {
        }
        public virtual DbSet<Agents> AGENTS { get; set; }
        public virtual DbSet<Customer> CUSTOMER { get; set; }
        public virtual DbSet<Orders> ORDERS { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMapping { get; set; }
        public virtual DbSet<User> SysUser { get; set; }
        public virtual DbSet<SysUserMenuMapping> SysUserMenuMapping { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.WeChat)
                .IsUnicode(false);
        }
    }
}
