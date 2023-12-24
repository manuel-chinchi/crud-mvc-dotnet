using crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class BaseController : Controller
    {
        protected IArticleService articleService { get; set; }
        protected ICategoryService categoryService { get; set; }

        private ISession _session;
        private ISession Session
        {
            get
            {
                if (_session == null)
                {
                    return HttpContext?.Session;
                }
                return null;
            }
        }

        protected string AppTheme
        {
            get
            {
                if (Session != null)
                {
                    return Session.GetString("AppTheme");
                }
                return null;
            }
            set
            {
                if (Session != null)
                {
                    Session.SetString("AppTheme", value);
                }
            }
        }

        protected bool? ThemeActivated
        {
            get
            {
                if (Session != null)
                {
                    return Convert.ToBoolean(Session.GetInt32("ThemeActivated"));
                }
                return false;
            }
            set
            {
                Session.SetInt32("ThemeActivated", Convert.ToInt32(value));
            }
        }

        public BaseController()
        {
            articleService = new ArticleService();
            categoryService = new CategoryService();
        }

        [HttpPost(Name = "/Base/ChangeTheme")]
        public JsonResult ChangeTheme(string theme)
        {
            AppTheme = theme;
            ThemeActivated = !ThemeActivated;

            var data = new
            {
                theme = AppTheme,
                themeActivated = ThemeActivated
            };

            return Json(data);
        }
    }
}
