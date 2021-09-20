using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace Kulala.Learning.CodeFirst
{
    public partial class CodeFirstModel : DbContext
    {
        public CodeFirstModel()
            : base("name=CodeFirstModel")
        {
        }

        public virtual DbSet<Log> SysLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<Role> SysRole { get; set; }
        public virtual DbSet<SysRoleMenuMapping> SysRoleMenuMapping { get; set; }
        public virtual DbSet<User> SysUser { get; set; }
        public virtual DbSet<SysUserMenuMapping> SysUserMenuMapping { get; set; }
        public virtual DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("SysRole").Property(c => c.Title).HasColumnName("Text");

            modelBuilder.Configurations.Add(new LogMapping());

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

        public class LogMapping : EntityTypeConfiguration<Log>
        {
            public LogMapping()
            {
                ToTable("SysLog");
                Property(c => c.Content).HasColumnName("Detail");
            }
        }
    }
}
