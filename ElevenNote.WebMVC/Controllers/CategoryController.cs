using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var cService = new CategoryService();
            var categories = cService.GetCategories();

            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate category)
        {
            if (!ModelState.IsValid) return View(category);

            var cService = CreateCategoryService();

            
            return View(category);

        }

        public ActionResult Details(int categoryId)
        {
            var svc = CreateCategoryService();
            var cService = svc.GetCategoryById(categoryId);

            return View(cService);
        }

        public ActionResult Edit(int categoryId)
        {
            var cService = CreateCategoryService();
            var detail = cService.GetCategoryById(categoryId);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    CategoryName = detail.CategoryName
                };
            return View(cService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int categoryId, CategoryEdit category)
        {
            if (!ModelState.IsValid) return View(category);

            if (category.CategoryId != categoryId)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(category);
            }

            var cService = CreateCategoryService();

            if (cService.UpdateCategory(category))
            {
                TempData["SaveResult"] = "Your note was updated!";
                return View(category);
            }

            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int categoryId)
        {
            var svc = CreateCategoryService();
            var category = svc.GetCategoryById(categoryId);

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int categoryId)
        {
            var cService = CreateCategoryService();

            cService.DeleteCategory(categoryId);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }









        private CategoryService CreateCategoryService()
        {
            var cService = new CategoryService();
            return cService;
        }


    }

}