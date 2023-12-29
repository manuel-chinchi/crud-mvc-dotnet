using crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        private ISession Session
        {
            get
            {
                return HttpContext?.Session;
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

        protected string ThemeOn
        {
            get
            {
                if (Session != null)
                {
                    return Session.GetString("ThemeOn");
                }
                return null;
            }
            set
            {
                if (Session != null)
                {
                    Session.SetString("ThemeOn", value);
                }
            }
        }

        protected string ThemeOff
        {
            get
            {
                if (Session != null)
                {
                    return Session.GetString("ThemeOff");
                }
                return null;
            }
            set
            {
                if (Session != null)
                {
                    Session.SetString("ThemeOff", value);
                }
            }
        }

        protected bool Flag
        {
            get
            {
                if (Session != null)
                {
                    return Convert.ToBoolean(Session.GetString("Flag"));
                }
                return false;
            }
            set
            {
                if (Session != null)
                {
                    Session.SetString("Flag", Convert.ToString(value));
                }
            }
        }

        public BaseController()
        {
            articleService = new ArticleService();
            categoryService = new CategoryService();
        }

        [HttpPost(Name = "/Base/ChangeTheme")]
        public JsonResult ChangeTheme(string themeOn, string themeOff, bool flag)
        {
            ThemeOn = themeOn;
            ThemeOff = themeOff;
            Flag = flag;

            var data = new
            {
                themeOn = ThemeOn,
                themeOff = ThemeOff,
                flag = Flag
            };

            return Json(data);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (Session != null && Session.Keys.Count() == 0)
            {
                ThemeOn = "/lib/bootstrap/dist/css/bootstrap.css";
                ThemeOff = "/lib/bootswatch/css/bootstrap.css";
                Flag = false;
            }

            ViewBag.ThemeOn = ThemeOn;
            ViewBag.ThemeOff = ThemeOff;
            ViewBag.Flag = Flag;
        }
    }
}
