using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }    
        public DbSet<Sale> Sales {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFTest511;Integrated Security=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No Description");


            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .HasMaxLength(100);               
            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);


            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .HasMaxLength(80);


            modelBuilder.Entity<Sale>()
                .Property(e => e.Date)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.CustomerId);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Store)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.StoreId);
        }
    }
}
