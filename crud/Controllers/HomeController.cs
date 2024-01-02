using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var data = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                { "urlJquery", "https://jquery.com/" },
                { "urlBootstrap", "https://getbootstrap.com/" },
                { "urlBootswatch", "https://bootswatch.com/"},
                { "urlDatatables", "https://datatables.net/"},
                { "urlEF6", "https://www.nuget.org/packages/EntityFramework/" },
                { "urlChartjs", "https://www.chartjs.org/" },
                { "urlJszip", "https://stuk.github.io/jszip/" },
                { "urlPdfmake", "http://pdfmake.org/#/" },
                { "title", "Información del proyecto" },
                { "message", "Sistema CRUD hecho en C# con .NET Core" },
                { "repository", "https://github.com/manuel-chinchi/crud-mvc-dotnet"  }
            };

            return View(data);
        }
    }
}
