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
        public List<ArticleModel> articles { get; set; }

        public ArticleController()
        {
            // TODO 1: Lista de articulos (hardcodeada). Esta lista la debería traer el 'service' de articulos -> ArticleService
            articles = new List<ArticleModel>()
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
        public IActionResult Create()
        {
            ViewBag.Message = "Ingrese los datos del nuevo artículo";
            return View();
        }

        // GET: ArticleController/Details/{int:id}
        public IActionResult Details(int id)
        {
            ArticleModel articleSelected = articles.Find(a => a.Id == id);
            return View(articleSelected);
        }

        // GET: ArticleController/ListDetails
        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de articulos existentes";
            ViewBag.Articles = articles;

            return View();
        }

        // GET: ArticleController/Edit/{int:id}
        public IActionResult Edit(int id)
        {
            // TODO 4: Busco el articulo seleccionado, esto lo haría el 'service' de articulos
            ArticleModel articleSelected = articles.Find(a => a.Id == id);
            return View(articleSelected);
        }

        // GET: ArticleController/Delete/{int:id}
        public IActionResult Delete(int id)
        {
            ViewBag.Message = "Esta página todavía no esta hecha. Sepa disculpar.";
            return View("Error");
        }
    }
}
