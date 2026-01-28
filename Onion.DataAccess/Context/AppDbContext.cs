using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Onion.Core.Entities;
using Onion.DataAccess.Interceptor;

namespace Onion.DataAccess.Context  
{
    internal class AppDbContext(BaseAuditableInterceptor _interceptor, DbContextOptions options) : DbContext(options)
    {
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
