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
            ViewBag.Message = "Ingrese los datos del nuevo artículo";

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
        public IActionResult Create(ArticleModel article)
        {
            if (articleService.IsValidArticle(article) == true)
            {
                ViewBag.MessageCreateSuccess = "Se ha agregado el articulo";

                articleService.InsertArticle(article);
            }
            else
            {
                ViewBag.MessageCreateError = "Error. Todos los campos del articulo deben tener un valor.";
            }

            ViewBag.Articles = articleService.GetArticles();

            return View("ListDetails");
        }

        public IActionResult Details(int id)
        {
            return View(articleService.GetArticle(id));
        }

        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de articulos existentes";

            ViewBag.Articles = articleService.GetArticles();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(articleService.GetArticle(id));
        }

        [HttpPost]
        public IActionResult Edit(ArticleModel article)
        {
            if (articleService.UpdateArticle(article) == true)
            {
                ViewBag.MessageEditSuccess = "Se ha actualizado el articulo";
            }
            else
            {
                ViewBag.MessageEditSuccess = "No se realizaron cambios en el articulo";
            }

            ViewBag.Articles = articleService.GetArticles();

            return View("ListDetails");
        }

        public IActionResult Delete(int id)
        {
            articleService.DeleteArticle(id);

            ViewBag.Articles = articleService.GetArticles();

            return View("ListDetails");
        }
    }
}
