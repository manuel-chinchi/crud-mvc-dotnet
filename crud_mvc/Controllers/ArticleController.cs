using crud_mvc.Models;
using crud_mvc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleService articleService { get; set; }

        public ArticleController()
        {
            articleService = new ArticleService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Message = "Ingrese los datos del artículo";

            string[] categories =
            {
                "",
                "Muebles",
                "Electrodomesticos",
                "Herramientas",
                "Limpieza",
                "Otro"
            };

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (articleService.IsValidArticle(article) == true)
            {
                TempData["MessageSuccess"] = "Se ha agregado el artículo.";

                articleService.InsertArticle(article);
            }
            else
            {
                TempData["MessageError"] = "Error. Todos los campos del artículo deben tener un valor.";
            }

            return RedirectToAction("ListDetails");
        }

        public IActionResult Details(int id)
        {
            return View(articleService.GetArticle(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Message = "Datos del artículo";

            return View(articleService.GetArticle(id));
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            if (articleService.UpdateArticle(article) == true)
            {
                TempData["MessageSuccess"] = "Se ha actualizado el artículo";
            }
            else
            {
                TempData["MessageWarning"] = "No se realizaron cambios en el artículo";
            }

            return RedirectToAction("ListDetails");
        }

        public IActionResult Delete(int id)
        {
            TempData["MessageSuccess"] = "Se ha eliminado el artículo";

            articleService.DeleteArticle(id);

            return RedirectToAction("ListDetails");
        }

        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de articulos existentes";

            return View(articleService.GetArticles());
        }
    }
}
