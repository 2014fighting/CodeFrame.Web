using System;
using CodeFrame.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace CodeFrame.Models
{
    public class CodeFrameContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        
        public DbSet<RoleInfo> RoleInfo { get; set; }


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
        }
    }
 
}
