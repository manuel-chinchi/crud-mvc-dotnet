using crud_mvc.Models;
using crud_mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Controllers
{
    public class BaseController : Controller
    {
        protected IArticleService articleService { get; set; }
        protected ICategoryService categoryService { get; set; }

        public BaseController()
        {
            articleService = new ArticleService();
            categoryService = new CategoryService();
        }
    }
}
