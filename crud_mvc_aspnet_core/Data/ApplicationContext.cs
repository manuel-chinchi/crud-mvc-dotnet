using crud_mvc_aspnet_core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace crud_mvc_aspnet_core.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ApplicationConfiguration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configure_Articles
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Article>().Property(a => a.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.Description).HasMaxLength(50);
            #endregion

            #region Configure_Categories
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            #endregion

            #region Load_Test_Data
            ApplicationData.Load(modelBuilder);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
