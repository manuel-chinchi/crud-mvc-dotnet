using crud_mvc_aspnet_core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Controllers
{
    public class ReportController : BaseController
    {
        public IActionResult Reports()
        {
            ViewBag.ChartTypes = new List<ChartInfo>()
            {
                new ChartInfo() { Name = "Pastel", Value = "pie" },
                new ChartInfo() { Name = "Barras", Value = "bar" }
            };

            ViewBag.Title = "Reportes";
            ViewBag.Message = "Lista de reportes";

            return View();
        }

        [HttpPost]
        public JsonResult GetDataCategories()
        {
            List<object> dataCategories = categoryService.
                GetCategories().
                Select(c => new
                {
                    name = c.Name,
                    quantity = c.Articles.Count
                }).
                Cast<object>().
                ToList();

            return Json(dataCategories);
        }
    }
}
