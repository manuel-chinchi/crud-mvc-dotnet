﻿using crud_mvc_aspnet_core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Controllers
{
    public class BaseController : ApplicationController
    {
        protected IArticleService articleService { get; set; }
        protected ICategoryService categoryService { get; set; }

        public BaseController()
        {
            articleService = new ArticleService();
            categoryService = new CategoryService();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            SetDefaultGlobalValues();
        }
    }
}
