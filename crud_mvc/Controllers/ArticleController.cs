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
        public CategoryService categoryService { get; set; }

        public ArticleController()
        {
            articleService = new ArticleService();
            categoryService = new CategoryService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Message = "Ingrese los datos del artículo";
            ViewBag.Categories = categoryService.GetCategories();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            #region Recuperar_Categoria
            article.Category = categoryService.GetCategory(article.CategoryId);
            #endregion

            if (ModelState.IsValid)
            {
                articleService.InsertArticle(article);

                TempData["AlertMessage"] = "Se ha agregado el artículo.";
                TempData["AlertStyle"] = AlertConstants.SUCCESS;
            }
            else
            {
                TempData["AlertMessage"] = "Error. Todos los campos del artículo deben tener un valor.";
                TempData["AlertStyle"] = AlertConstants.WARNING;
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
            ViewBag.Categories = categoryService.GetCategories();

            return View(articleService.GetArticle(id));
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            #region Recuperar_Categoria
            article.Category = categoryService.GetCategory(article.CategoryId);
            #endregion

            if (ModelState.IsValid)
            {
                articleService.UpdateArticle(article);

                TempData["AlertMessage"] = "Se ha actualizado el artículo";
                TempData["AlertStyle"] = AlertConstants.SUCCESS;
            }
            else
            {
                TempData["MessageWarning"] = "No se realizaron cambios en el artículo";
                TempData["AlertStyle"] = AlertConstants.WARNING;
            }

            return RedirectToAction("ListDetails");
        }

        public IActionResult Delete(int id)
        {
            TempData["MessageSuccess"] = "Se ha eliminado el artículo";
            TempData["AlertStyle"] = AlertConstants.SUCCESS;

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
