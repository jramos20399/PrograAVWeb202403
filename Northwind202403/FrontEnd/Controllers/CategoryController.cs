using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryHelper _categoryHelper;

        public CategoryController(ICategoryHelper categoryHelper)
        {
            _categoryHelper = categoryHelper;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            _categoryHelper.Token = HttpContext.Session.GetString("token");
            var lista = _categoryHelper.GetCategories();
            return View(lista);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryHelper.GetCategory(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel    category)
        {
            try
            {
                _categoryHelper.Add(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryHelper.GetCategory(id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            try
            {
                _categoryHelper.Update(category
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            var category = _categoryHelper.GetCategory(id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryViewModel category)
        {
            try
            {
                _categoryHelper.Delete(category.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
