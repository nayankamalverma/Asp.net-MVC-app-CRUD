using Asp.net_MVC_app_CRUD.Data;
using Asp.net_MVC_app_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Asp.net_MVC_app_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }

        //Get method
        public IActionResult Create() {
            return View();
        }

        //post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) { return NotFound(); }
            var category = _db.Categories.Find(id);
            if(category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var category = _db.Categories.Find(id);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj = _db.Categories.Find(id);
            if(obj == null) { return NotFound(); }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }


    }
}
