using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace crud_mvc.Data
{
    public class InventaryContext : DbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GTSPB4M\\SQLEXPRESS; Database=Inventory_MVC; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleModel>().HasData
            (
                new ArticleModel() { Id = 1, Name = "Escoba", Category = "Otro", Description = "1.2m", Quantity = 20, IsEnabled = true },
                new ArticleModel() { Id = 2, Name = "Balde", Category = "Otro", Description = "4l", Quantity = 50, IsEnabled = true },
                new ArticleModel() { Id = 3, Name = "Playstation 2", Category = "Otro", Description = "Sony, usada", Quantity = 5, IsEnabled = true }
            );
        }
    }
}
