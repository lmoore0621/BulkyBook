using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;    
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create() 
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomerError", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        //Update
        [HttpPut]
        public IActionResult Update(Category category)
        {
            var oldCategory = _db.Categories.FirstOrDefault(x => x.Id == category.Id);

            if (category != null && oldCategory != null)
            {
                oldCategory.Name = category.Name;
                oldCategory.DisplayOrder = category.DisplayOrder;
                oldCategory.CreatedDateTime = category.CreatedDateTime;

                _db.Categories.Add(oldCategory);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(oldCategory);
        }
    }
}