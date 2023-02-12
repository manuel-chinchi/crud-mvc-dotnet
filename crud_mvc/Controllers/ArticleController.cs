using crud_mvc.Models;
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
        public static List<ArticleModel> s_articles { get; set; }

        public ArticleController()
        {
            // TODO 1: Lista de articulos (hardcodeada). Esta lista la debería traer el 'service' de articulos -> ArticleService
            s_articles = new List<ArticleModel>()
            {
                new ArticleModel { Id = 1, Name = "Escoba", Category = "Otro", Description = "Chica - 130cm x 4cm" },
                new ArticleModel { Id = 2, Name = "Balde", Category = "Otro", Description = "20cm x 22cm" },
                new ArticleModel { Id = 3, Name = "Consola juegos", Category = "Otro", Description = "Play 2 - usada - chipeada" }
            };
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
                "Otro",
                "Muebles",
                "Electrodomesticos",
                "Herramientas",
                "Limpieza"
            };

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleModel article)
        {
            ViewBag.Articles = s_articles;

            if (string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Category) || string.IsNullOrEmpty(article.Description))
            {
                ViewBag.MessageCreateError = "Error. Todos los campos del articulo deben tener un valor.";
            }
            else
            {
                ViewBag.MessageCreateSuccess = "Se ha agregado el articulo";

                article.Id = s_articles.Count + 1;

                s_articles.Add(article);
            }

            return View("ListDetails");
        }

        public IActionResult Details(int id)
        {
            ArticleModel articleSelected = s_articles.Find(a => a.Id == id);

            return View(articleSelected);
        }

        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de articulos existentes";

            ViewBag.Articles = s_articles;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO 4: Busco el articulo seleccionado, esto lo haría el 'service' de articulos
            ArticleModel articleSelected = s_articles.Find(a => a.Id == id);

            return View(articleSelected);
        }

        [HttpPost]
        public IActionResult Edit(ArticleModel article)
        {
            ArticleModel articleEdit = s_articles.Find(a => a.Id == article.Id);

            if (articleEdit.Equals(article) == true)
            {
                ViewBag.MessageEditSuccess = "No se realizaron cambios en el articulo";
            }
            else
            {
                int indexArticleEdit = s_articles.FindIndex(a => a.Id == article.Id);

                s_articles[indexArticleEdit] = article;

                ViewBag.MessageEditSuccess = "Se ha actualizado el articulo";
            }

            ViewBag.Articles = s_articles;

            return View("ListDetails");
        }

        public IActionResult Delete(int id)
        {
            ArticleModel articleDelete = s_articles.Find(a => a.Id == id);

            s_articles.Remove(articleDelete);

            ViewBag.Articles = s_articles;

            return View("ListDetails");
        }
    }
}
