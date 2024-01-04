using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public partial class ApplicationConstants
    {
        // Keys used for save values in Session
        public const string K_SWITCH_IS_ACTIVE = "SwitchIsActive";
        public const string K_THEME_ON = "ThemeOn";
        public const string K_THEME_OFF = "ThemeOff";

        // Paths of css file themes
        public const string FILE_THEME_LIGHT = "/lib/bootstrap/dist/css/bootstrap.css";
        public const string FILE_THEME_DARK = "/lib/bootswatch/css/bootstrap-darkly.css";
    }

    public class ApplicationController : Controller
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
                    return _session.GetString(ApplicationConstants.K_THEME_ON);
                }
                return null;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(ApplicationConstants.K_THEME_ON, value);
                }
            }
        }

        protected string ThemeOff
        {
            get
            {
                if (_session != null)
                {
                    return _session.GetString(ApplicationConstants.K_THEME_OFF);
                }
                return null;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(ApplicationConstants.K_THEME_OFF, value);
                }
            }
        }

        protected bool SwitchIsActive
        {
            get
            {
                if (_session != null)
                {
                    return Convert.ToBoolean(_session.GetString(ApplicationConstants.K_SWITCH_IS_ACTIVE));
                }
                return false;
            }
            set
            {
                if (_session != null)
                {
                    _session.SetString(ApplicationConstants.K_SWITCH_IS_ACTIVE, Convert.ToString(value));
                }
            }
        }

        [HttpPost(Name = "Application/ChangeAppTheme")]
        public JsonResult ChangeTheme(string themeOn, string themeOff, bool switchIsActive)
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
            if (!keys.Contains(ApplicationConstants.K_THEME_ON) && !keys.Contains(ApplicationConstants.K_THEME_ON) &&
                !keys.Contains(ApplicationConstants.K_SWITCH_IS_ACTIVE))
            {
                ThemeOn = ApplicationConstants.FILE_THEME_LIGHT;
                ThemeOff = ApplicationConstants.FILE_THEME_DARK;
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
                ViewBag.ThemeOn = ApplicationConstants.FILE_THEME_DARK;
                ViewBag.ThemeOff = ApplicationConstants.FILE_THEME_LIGHT;
                ViewBag.SwitchIsActive = true;
                _defaultLightTheme = true;
            }
        }

        public void SetDefaultLightTheme(bool opt = true)
        {
            _defaultLightTheme = opt;
        }
        #endregion

        #region Configure global variables

        public void SetDefaultVariables()
        {
            ViewBag.AppName = "crud_mvc_dotnet";
            ViewBag.AppVersion = "v1.2.1";
            ViewBag.AppTitle = ViewBag.AppName + " " + ViewBag.AppVersion + " (Proyecto)";
        }

        #endregion
    }
}
