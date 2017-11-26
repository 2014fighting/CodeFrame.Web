using System;
using System.Collections.Generic;
using System.Text;
using CodeFrame.XUnit.Entity;
using Microsoft.EntityFrameworkCore;


namespace CodeFrame.XUnit
{
    public class InMemoryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");
        }
 
    }
}
