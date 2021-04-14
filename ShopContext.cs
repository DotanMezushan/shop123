using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace shop
{
    class ShopContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<ContactDetails> ContactsDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrdersProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=New123Shop;Integrated Security=True");
            //optionsBuilder.LogTo((m) => Debug.WriteLine(m)).EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasOne(c=>c.Custumer_contact_ditals)
               .WithOne(c => c.Cusrumer)
               .HasForeignKey<Customers>(c => c.CustumeID);

            modelBuilder.Entity<Customers>(e =>
            {
                //e.HasOne<ContactDetails>();
                e.HasKey(c=>c.CustumeID);
                e.Property(c => c.CustumeID).ValueGeneratedNever();
                e.Property(c=>c.CustomerName).IsRequired().HasMaxLength(16);
                e.HasIndex(c=>c.CustomerName).IsUnique();
            });

            modelBuilder.Entity<ContactDetails>().HasKey(c => c.CustumeID);
            modelBuilder.Entity<ContactDetails>(e =>
            {
                e.Property(c => c.CustumeID).ValueGeneratedNever();
                e.Property(c => c.Email).HasMaxLength(256).HasColumnType("varchar(256)");
                e.HasIndex(c => c.Email).IsUnique();
                e.Property(c => c.Phone).HasMaxLength(16).HasColumnType("varchar(16)");
                e.HasIndex(c => c.Phone).IsUnique();
            });
            modelBuilder.Entity<Product>(e =>
            {
                e.Property(p=>p.ProductID).ValueGeneratedNever();
                e.Property(p=>p.ProductName).IsRequired().HasMaxLength(16);
                e.HasIndex(p=>p.ProductName).IsUnique();

             });
      
            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(o => o.OredrID);
                e.Property(o=>o.OredrID).ValueGeneratedNever();
                e.Property(o=>o.Created).HasColumnType("datetime").HasDefaultValueSql("getdate()");

                e.HasOne<Customers>(c => c.Custumer)
                .WithMany(c => c.Orders);
                //.HasForeignKey(o => o.OredrID);
            });
            modelBuilder.Entity<OrderProduct>(e =>
            {
                e.HasKey(op => new { op.OredrID, op.ProductID });
                e.HasOne<Order>(o => o.Order)
                .WithMany(o => o.Order_Product)
                .HasForeignKey(o => o.OredrID);
                e.HasOne<Product>(op => op.Product)
                .WithMany(p => p.Order_Product)
                .HasForeignKey(op => op.ProductID);
            });
        }
    }
}
