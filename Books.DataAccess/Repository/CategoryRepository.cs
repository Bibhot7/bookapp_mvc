using bookapp.DataAccess.Data;
using bookapp.DataAccess.Repository.IRepository;
using bookapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bookapp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

       

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
