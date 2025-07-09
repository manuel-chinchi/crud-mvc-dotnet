using crud_mvc_aspnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Services
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();

        public Category GetCategory(int id);

        public void CreateCategory(Category category);

        public void DeleteCategory(int id);
    }
}
