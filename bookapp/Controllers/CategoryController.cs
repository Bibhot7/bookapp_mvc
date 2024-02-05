using bookapp.Data;
using Microsoft.AspNetCore.Mvc;
using bookapp.Models;

namespace bookapp.Controllers
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
                return RedirectToAction("Index");
            }
           return View();
        }
    }
}
