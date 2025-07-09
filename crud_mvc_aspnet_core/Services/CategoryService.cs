using crud_mvc_aspnet_core.Data;
using crud_mvc_aspnet_core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService() { }

        public List<Category> GetCategories()
        {
            using (var db = new ApplicationContext())
            {
                return db.Categories.Include(c => c.Articles).ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Categories.FirstOrDefault(c => c.Id == id);
            }
        }

        public void CreateCategory(Category category)
        {
            using (var db = new ApplicationContext())
            {
                db.Categories.Add(new Category()
                {
                    Name = category.Name,
                    DateCreated = DateTime.Now
                });

                db.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (var db = new ApplicationContext())
            {
                var category = this.GetCategory(id);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
            }
        }
    }
}
