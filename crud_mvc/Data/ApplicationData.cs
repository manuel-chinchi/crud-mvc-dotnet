using crud_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Data
{
    public static class ApplicationData
    {
        public static void Load(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Indumentaria" },
                new Category() { Id = 2, Name = "Herramientas" },
                new Category() { Id = 3, Name = "Electrodomésticos" },
                new Category() { Id = 4, Name = "Ocio" },
                new Category() { Id = 5, Name = "Otro" }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article() { Id = 1, Name = "camisa deportiva", Description = "Adidas, poliester", Quantity = 90, CategoryId = 1 },
                new Article() { Id = 2, Name = "pantalon deportivo", Description = "Adidas, poliester 95%", Quantity = 120, CategoryId = 1 },
                new Article() { Id = 3, Name = "calzones boxer", Description = "Calvin Klein", Quantity = 100, CategoryId = 1 },
                new Article() { Id = 4, Name = "calzones boxer", Description = "Kevingston", Quantity = 50, CategoryId = 1 },
                new Article() { Id = 5, Name = "jean", Description = "Nike", Quantity = 150, CategoryId = 1 },
                new Article() { Id = 6, Name = "jean", Description = "Gucci", Quantity = 180, CategoryId = 1 },

                new Article() { Id = 7, Name = "martillo neumatico", Description = "Bosch", Quantity = 120, CategoryId = 2 },
                new Article() { Id = 8, Name = "desmalezadora", Description = "Makita, año 2010", Quantity = 120, CategoryId = 2 },
                new Article() { Id = 9, Name = "amoladora", Description = "Stanley, año 2015", Quantity = 30, CategoryId = 2 },
                new Article() { Id = 10, Name = "desmalezadora", Description = "Hyundai", Quantity = 60, CategoryId = 2 },

                new Article() { Id = 11, Name = "heladera", Description = "Gaffa", Quantity = 60, CategoryId = 3 },
                new Article() { Id = 12, Name = "lavarropas", Description = "Electroluz", Quantity = 40, CategoryId = 3 },
                new Article() { Id = 13, Name = "cocina", Description = "General Electric", Quantity = 50, CategoryId = 3 },
                new Article() { Id = 14, Name = "heladera", Description = "LG, año 2012", Quantity = 30, CategoryId = 3 },
                new Article() { Id = 15, Name = "heladera", Description = "LG, reacondicionadas/nuevas", Quantity = 100, CategoryId = 3 },
                new Article() { Id = 16, Name = "lavavajillas", Description = "Sanyo, año 2005", Quantity = 20, CategoryId = 3 },

                new Article() { Id = 17, Name = "consola xbox", Description = "Microsoft, nuevas", Quantity = 200, CategoryId = 4 },
                new Article() { Id = 18, Name = "sega", Description = "modelo Genesis 3, a reparar/nuevas", Quantity = 80, CategoryId = 4 },
                new Article() { Id = 19, Name = "consola playstation 2", Description = "original, a reparar/nuevas", Quantity = 120, CategoryId = 4 },
                new Article() { Id = 20, Name = "lapiz 3D impresora", Description = "generico", Quantity = 100, CategoryId = 4 },
                new Article() { Id = 21, Name = "monopoli", Description = "Hasbro, año 2000", Quantity = 30, CategoryId = 4 }
            );
        }
    }
}
