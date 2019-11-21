using BlazorShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            //Category obj = new Category();
            return _db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category objCategory)
        {
            try
            {
                _db.Categories.Add(objCategory);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
           
        }

        public bool UpdateCategory(Category objCategory)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == objCategory.CategoryId);

            if(ExistingCategory != null)
            {
                ExistingCategory.CategoryName = objCategory.CategoryName;
                try
                {

                    _db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    return false;
                }
            }
            else
            {
                return false;
            }
         }


        public bool DeleteCategory(Category objCategory)
        {
            var ExistingCategory = _db.Categories.FirstOrDefault(c => c.CategoryId == objCategory.CategoryId);

            if (ExistingCategory != null)
            {
                try
                {
                    _db.Categories.Remove(ExistingCategory);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
