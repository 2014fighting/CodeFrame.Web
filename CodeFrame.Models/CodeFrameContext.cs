using System;
using CodeFrame.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace CodeFrame.Models
{
    /// <inheritdoc />
    /// <summary>
    /// 参考文档 https://docs.microsoft.com/en-us/ef/core/modeling/relationships
    /// </summary>
    public class CodeFrameContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        
        public DbSet<RoleInfo> RoleInfo { get; set; }

        public DbSet<Table> Table { get; set; }

        public DbSet<SubSystem> SubSystem { get; set; }
        public DbSet<RolePower> RolePower { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<DepartMent> DepartMent { get; set; }
        public DbSet<Button> Button { get; set; }
        public DbSet<Column> Column { get; set; }

        public CodeFrameContext(DbContextOptions<CodeFrameContext> options) : base(options)
        {
        }
        //private string _connection;

        //public CodeFrameContext(string connection) => this._connection = connection;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!string.IsNullOrWhiteSpace(_connection))
        //        optionsBuilder.UseMySql(_connection);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.UserInfo)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.RoleInfo)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.EnableAutoHistory(Int32.MaxValue);
        }
    }
 
}
