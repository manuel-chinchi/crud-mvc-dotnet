using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class AppController : Controller
    {
        #region Configure theme

        private ISession Session
        {
            get
            {
                return HttpContext?.Session;
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

        protected bool SwitchIsActive
        {
            get
            {
                if (Session != null)
                {
                    return Convert.ToBoolean(Session.GetString("SwitchIsActive"));
                }
                return false;
            }
            set
            {
                if (Session != null)
                {
                    Session.SetString("SwitchIsActive", Convert.ToString(value));
                }
            }
        }

        [HttpPost(Name = "/Base/ChangeAppTheme")]
        public JsonResult ChangeAppTheme(string themeOn, string themeOff, bool switchIsActive)
        {
            ThemeOn = themeOn;
            ThemeOff = themeOff;
            SwitchIsActive = switchIsActive;

            var data = new
            {
                themeOn = ThemeOn,
                themeOff = ThemeOff,
                switchIsActive = SwitchIsActive
            };

            return Json(data);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (Session != null && Session.Keys.Count() == 0)
            {
                ThemeOn = "/lib/bootstrap/dist/css/bootstrap.css";
                ThemeOff = "/lib/bootswatch/css/bootstrap.css";
                SwitchIsActive = false;
            }

            ViewBag.ThemeOn = ThemeOn;
            ViewBag.ThemeOff = ThemeOff;
            ViewBag.SwitchIsActive = SwitchIsActive;
        }
        
        #endregion
    }
}
