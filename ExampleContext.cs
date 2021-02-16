using CustomMapping.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMapping
{
    public class ExampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=DbName; Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Veritabanındaki tablolarla proje içerisindeki tabloların map işlemi
            //default database schema
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Product>().ToTable("Products");
            //modelBuilder.Entity<Product>().ToTable("Products","dbo");

            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("Name");
        }

        public DbSet<Product> Products { get; set; }
    }
}
