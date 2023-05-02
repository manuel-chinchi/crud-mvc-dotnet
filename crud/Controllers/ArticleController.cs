using crud_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Controllers
{
    public class ArticleController : BaseController
    {
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
            article.Category = categoryService.GetCategory(article.CategoryId);

            if (ModelState.IsValid)
            {
                articleService.InsertArticle(article);

                TempData["AlertMessage"] = "Se ha agregado el artículo.";
                TempData["AlertStyle"] = AlertConstants.SUCCESS;

                return RedirectToAction("ListDetails");
            }

            return View();
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
            article.Category = categoryService.GetCategory(article.CategoryId);

            if (ModelState.IsValid)
            {
                articleService.UpdateArticle(article);

                TempData["AlertMessage"] = "Se ha actualizado el artículo";
                TempData["AlertStyle"] = AlertConstants.SUCCESS;

                return RedirectToAction("ListDetails");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            TempData["AlertMessage"] = "Se ha eliminado el artículo '" + articleService.GetArticle(id).Name + "'";
            TempData["AlertStyle"] = AlertConstants.SUCCESS;

            articleService.DeleteArticle(id);

            return RedirectToAction("ListDetails");
        }

        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de artículos existentes";

            return View(articleService.GetArticles());
        }
    }
}
