using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        IProductHelper _productHelper;
        ICategoryHelper _categoryHelper;
        ISupplierHelper _supplierHelper;
            public ProductController(IProductHelper productHelper, ICategoryHelper categoryHelper, ISupplierHelper supplierHelper)
        {
            this._productHelper = productHelper;
            _categoryHelper = categoryHelper;
            _supplierHelper = supplierHelper;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = _productHelper.GetAll();

            foreach (var item in products)
            {
                item.CategoryName = _categoryHelper.GetCategory(item.CategoryId).CategoryName;
            }

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ProductViewModel Product = new ProductViewModel();

            Product.Suppliers = _supplierHelper.GetAll();
            Product.Categories= _categoryHelper.GetCategories();

            return View(Product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                _productHelper.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = new ProductViewModel();

            product= _productHelper.GetById(id);
            product.Suppliers = _supplierHelper.GetAll();
            product.Categories = _categoryHelper.GetCategories();


            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {
                _productHelper.EdiProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
