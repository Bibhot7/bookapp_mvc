using bookapp.DataAccess.Data;
using bookapp.DataAccess.Repository.IRepository;
using bookapp.Models;
using bookapp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace bookapp.Areas.Admin.Controllers
   
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        //Getting the implementation of ApplicationDbContext.
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //Retriving all the categories.
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                //Adding message for the functionality after implementation, using TempData.
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();

            }

            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)

        {  //Deleting a category
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id); if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            //Adding message for the functionality after implementation, using TempData.
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");



        }
    }
}
