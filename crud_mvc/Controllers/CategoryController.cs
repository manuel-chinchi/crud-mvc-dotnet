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
    public class CategoryController : Controller
    {
        public CategoryService categoryService { get; set; }

        public CategoryController()
        {
            categoryService = new CategoryService();
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            return View();
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Message = "Ingrese los datos de la categoría";

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.InsertCategory(category);

                TempData["AlertMessage"] = "Se ha agregado la categoría.";
                TempData["AlertStyle"] = AlertConstants.SUCCESS;

                return RedirectToAction("ListDetails");
            }

            return View();
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ListDetails");
            }

            return View();
        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int id)
        {
            TempData["AlertMessage"] = "Se ha eliminado la categoría '" + categoryService.GetCategory(id).Name + "'";
            TempData["AlertStyle"] = AlertConstants.SUCCESS;

            categoryService.DeleteCategory(id);

            return RedirectToAction("ListDetails");
        }

        public IActionResult ListDetails()
        {
            ViewBag.Message = "Lista de categorias existentes.";

            return View(categoryService.GetCategories());
        }
    }
}
