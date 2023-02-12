using App_ABM_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_ABM_MVC.Controllers
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

        // GET: ArticleController
        public IActionResult Index()
        {
            return View();
        }

        // GET: ArticleController/Create
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
        public IActionResult Create(string name, string category, string description)
        {
            ViewBag.Articles = s_articles;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
            {
                ViewBag.MessageCreateError = "Error. Todos los campos del articulo deben tener un valor.";
            }
            else
            {
                ViewBag.MessageCreateSuccess = "Se ha agregado el articulo";

                s_articles.Add(new ArticleModel() { Id = (s_articles.Count + 1), Name = name, Category = category, Description = description });
            }

            return View("ListDetails");
        }

        // GET: ArticleController/Details/{int:id}
        public IActionResult Details(int id)
        {
            ArticleModel articleSelected = s_articles.Find(a => a.Id == id);

            return View(articleSelected);
        }

        // GET: ArticleController/ListDetails
        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de articulos existentes";

            ViewBag.Articles = s_articles;

            return View();
        }

        // GET: ArticleController/Edit/{int:id}
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

        // GET: ArticleController/Delete/{int:id}
        public IActionResult Delete(int id)
        {
            ArticleModel articleDelete = s_articles.Find(a => a.Id == id);

            s_articles.Remove(articleDelete);

            ViewBag.Articles = s_articles;

            return View("ListDetails");
        }
    }
}
