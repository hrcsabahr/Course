using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Course.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { 
            _db=db;
        }
        public IActionResult Index()
        {
            List<Category> objCategorList=_db.Categories.ToList();


            return View(objCategorList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot  exatly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created succesfully";
                return RedirectToAction("Index");
            }
           else
                { return View(); }
          
        }


        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id);
           
            if (categoryFromDb == null)
            {
                return NotFound();
            }
                return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
         

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edit succesfully";
                return RedirectToAction("Index");
            }
            
             return View(); 

        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? objFromDb = _db.Categories.Find(id);
            if (objFromDb  == null)
            {
                return NotFound();
            }
           
            _db.Categories.Remove(objFromDb);
            TempData["success"] = "Category delte  succesfully";
            _db.SaveChanges();
            return RedirectToAction("Index");
           

          

        }
    }
}
