using BlazorShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int productId)
        {
            //Product obj = new Product();
            return _db.Products.Include(c => c.Category).FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetProducts()
        {
            // Eager loading
            return _db.Products.Include(c=>c.Category).ToList();
        }


        public List<Category> GetCategoryList()
        {
            // Eager loading
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product objProduct)
        {
            try
            {
                _db.Products.Add(objProduct);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
           
        }

        public bool UpdateProduct(Product objProduct)
        {
            var ExistingProduct = _db.Products.FirstOrDefault(p => p.ProductId == objProduct.ProductId);

            if(ExistingProduct != null)
            {
                // check if new image is provided during the update then use the old image instead
                if(objProduct == null)
                {
                    objProduct.Image = ExistingProduct.Image;
                }
                try
                {
                    _db.Products.Update(objProduct);
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


        public bool DeleteProduct(Product objProduct)
        {
            // get the product
            var ExistingProduct = _db.Products.FirstOrDefault(p => p.ProductId == objProduct.ProductId);

            if (ExistingProduct != null)
            {
                try
                {
                    _db.Products.Remove(ExistingProduct);
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
