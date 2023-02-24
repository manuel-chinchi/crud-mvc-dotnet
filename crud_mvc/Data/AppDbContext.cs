using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace crud_mvc.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GTSPB4M\\SQLEXPRESS; Database=inventory_db; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Config_Articles
            modelBuilder.Entity<Article>().ToTable("articles");
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Article>().Property(a => a.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.Description).HasMaxLength(50);
            #endregion

            #region Config_Categories
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            #endregion

            #region SetCategories
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Otro" },
                new Category() { Id = 2, Name = "Indumentaria" },
                new Category() { Id = 3, Name = "Herramientas" }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
