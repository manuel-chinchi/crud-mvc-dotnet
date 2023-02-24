using crud_mvc.Data;
using crud_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        public List<Category> GetCategories()
        {
            using (var db = new AppDbContext())
            {
                return db.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Categories.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public Category GetCategoryByName(string name)
        {
            using (var db = new AppDbContext())
            {
                return db.Categories.Where(c => c.Name == name).FirstOrDefault();
            }
        }

    }
}
