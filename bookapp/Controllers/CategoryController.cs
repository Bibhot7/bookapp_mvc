
using bookapp.DataAccess.Data;
using bookapp.Models;
using Microsoft.AspNetCore.Mvc;


namespace bookapp.DataAccess.Controllers
{
    public class CategoryController : Controller
    {
        //Getting the implementation of ApplicationDbContext.
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            //Retriving all the categories.
            List <Category> objCategoryList = _db.Categories.ToList();
            //Passing the category in the view.
            return View(objCategoryList);


        }
        //Creating an action method for (Create new category method which will be invocked calling the view).
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
            
        {

            //Creating a category and adding a category.
            // checking for validation
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //Adding message for the functionality after implementation, using TempData.
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
           return View();
        }
        public IActionResult Edit(int? id)
        {   if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null) {
                return NotFound();

            }
            
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)

        {

           //Updating a category
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                //Adding message for the functionality after implementation, using TempData.
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
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
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)

        {  //Deleting a category
            Category? obj = _db.Categories.Find(id); if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            //Adding message for the functionality after implementation, using TempData.
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");


           
        }
    }
}
