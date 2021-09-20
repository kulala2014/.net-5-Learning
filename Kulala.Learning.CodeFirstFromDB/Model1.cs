using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Kulala.Learning.CodeFirstFromDB
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AGENTS> AGENTS { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMapping { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserMenuMapping> SysUserMenuMapping { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AGENTS>()
                .Property(e => e.AGENT_CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .Property(e => e.AGENT_NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .Property(e => e.WORKING_AREA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .Property(e => e.COMMISSION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .Property(e => e.PHONE_NO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<AGENTS>()
                .HasMany(e => e.CUSTOMER)
                .WithRequired(e => e.AGENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AGENTS>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.AGENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CUST_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CUST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CUST_CITY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.WORKING_AREA)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CUST_COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.PHONE_NO)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.AGENT_CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.CUST_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.AGENT_CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.ORD_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SysLog>()
                .HasOptional(e => e.SysLog1)
                .WithRequired(e => e.SysLog2);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SysMenu>()
                .Property(e => e.SourcePath)
                .IsUnicode(false);

            modelBuilder.Entity<SysUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<SysUser>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<SysUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SysUser>()
                .Property(e => e.WeChat)
                .IsUnicode(false);
        }
    }
}
