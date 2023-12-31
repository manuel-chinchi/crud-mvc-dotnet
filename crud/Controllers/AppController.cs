using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public partial class AppConstants
    {
        // Keys used for save values in Session
        public const string K_SWITCH_IS_ACTIVE = "SwitchIsActive";
        public const string K_THEME_ON = "ThemeOn";
        public const string K_THEME_OFF = "ThemeOff";

        // Paths of css file themes
        public const string FILE_THEME_LIGHT = "/lib/bootstrap/dist/css/bootstrap.css";
        public const string FILE_THEME_DARK = "/lib/bootswatch/css/bootstrap-darkly.css";
    }

    public class AppController : Controller
    {
        #region Configure theme

        private static bool _defaultLightTheme { get; set; } = true;
        private ISession _session
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
                if (_session != null)
                {
                    return _session.GetString(AppConstants.K_THEME_ON);
                }
                return null;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(AppConstants.K_THEME_ON, value);
                }
            }
        }

        protected string ThemeOff
        {
            get
            {
                if (_session != null)
                {
                    return _session.GetString(AppConstants.K_THEME_OFF);
                }
                return null;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(AppConstants.K_THEME_OFF, value);
                }
            }
        }

        protected bool SwitchIsActive
        {
            get
            {
                if (_session != null)
                {
                    return Convert.ToBoolean(_session.GetString(AppConstants.K_SWITCH_IS_ACTIVE));
                }
                return false;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(AppConstants.K_SWITCH_IS_ACTIVE, Convert.ToString(value));
                }
            }
        }

        [HttpPost(Name = "/App/ChangeAppTheme")]
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
            var keys = _session.Keys.ToList();

            //if (Session != null && Session.Keys.Count() == 0)
            if (!keys.Contains(AppConstants.K_THEME_ON) && !keys.Contains(AppConstants.K_THEME_ON) &&
                !keys.Contains(AppConstants.K_SWITCH_IS_ACTIVE))
            {
                ThemeOn = AppConstants.FILE_THEME_LIGHT;
                ThemeOff = AppConstants.FILE_THEME_DARK;
                SwitchIsActive = false;
            }

            if (_defaultLightTheme)
            {
                ViewBag.ThemeOn = ThemeOn;
                ViewBag.ThemeOff = ThemeOff;
                ViewBag.SwitchIsActive = SwitchIsActive;
            }
            else
            {
                ViewBag.ThemeOn = AppConstants.FILE_THEME_DARK;
                ViewBag.ThemeOff = AppConstants.FILE_THEME_LIGHT;
                ViewBag.SwitchIsActive = true;
                _defaultLightTheme = true;
            }
        }

        public void SetDefaultLightTheme(bool opt = true)
        {
            _defaultLightTheme = opt;
        }
        #endregion
    }
}
