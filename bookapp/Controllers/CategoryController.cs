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
    }
}
