using crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Services
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();

        public Category GetCategory(int id);

        public void InsertCategory(Category category);

        public void DeleteCategory(int id);
    }
}
