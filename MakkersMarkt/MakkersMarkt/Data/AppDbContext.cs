using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace MakkersMarkt.Data
{
    public class MakkersMarktContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<TypeMaterial> TypeMaterials { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Moderation> Moderations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;user=root;password=;database=MakkersMarkt",
                ServerVersion.Parse("8.0.30")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Maker" },
                new Role { Id = 3, Name = "Buyer" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, RoleId = 1, Name = "AdminUser", Password = "hashedpassword" },
                new User { Id = 2, RoleId = 2, Name = "MakerUser", Password = "hashedpassword" },
                new User { Id = 3, RoleId = 3, Name = "BuyerUser", Password = "hashedpassword" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Pending", Description = "Order is pending" },
                new Status { Id = 2, Name = "Shipped", Description = "Order has been shipped" },
                new Status { Id = 3, Name = "Completed", Description = "Order is completed" }
            );

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Wood", Description = "High-quality wood" },
                new Material { Id = 2, Name = "Metal", Description = "Durable metal" }
            );

            modelBuilder.Entity<Type>().HasData(
                new Type { Id = 1, Name = "Furniture", Description = "Handmade furniture" },
                new Type { Id = 2, Name = "Sculpture", Description = "Artistic sculptures" }
            );

            modelBuilder.Entity<TypeMaterial>().HasData(
                new TypeMaterial { Id = 1, MaterialId = 1, TypeId = 1 },
                new TypeMaterial { Id = 2, MaterialId = 2, TypeId = 2 }
            );

            modelBuilder.Entity<Specification>().HasData(
                new Specification { Id = 1, Description = "Strong and durable", Durability = 10 },
                new Specification { Id = 2, Description = "Lightweight and elegant", Durability = 7 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, MakerId = 2, TypeMaterialId = 1, SpecificationId = 1, ProductionTime = "5 days", Name = "Wooden Chair", Description = "Handmade wooden chair", CreatedAt = DateTime.UtcNow },
                new Product { Id = 2, MakerId = 2, TypeMaterialId = 2, SpecificationId = 2, ProductionTime = "10 days", Name = "Metal Sculpture", Description = "Artistic metal sculpture", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, BuyerId = 3, ProductId = 1, StatusId = 1, CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, OrderId = 1, Rating = 4.5f, Comment = "Great quality!", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, UserId = 1, Name = "New Order Received", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Moderation>().HasData(
                new Moderation { Id = 1, UserId = 1, ModeratorId = 2 }
            );
        }
    }
}
