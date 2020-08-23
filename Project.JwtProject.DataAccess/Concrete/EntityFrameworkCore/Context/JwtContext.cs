using Microsoft.EntityFrameworkCore;
using Project.JwtProject.DataAccess.Concrete.Mapping;
using Project.JwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.JwtProject.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class JwtContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=JwtDb;integrated security=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
