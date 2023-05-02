using crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Controllers
{
    public class CategoryController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Message = "Ingrese los datos de la categoría";

            return View();
        }

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
