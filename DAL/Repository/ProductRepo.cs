using DAL.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepo
    {
        public List<Product> GetAll()
        {
            var db = new ShopContext();
            return db.Product.ToList();
        }
        public Product GetById(int id)
        {
            var db = new ShopContext();
            Product product = new Product();
            product = db.Product.FirstOrDefault(x => x.Id == id);

            return product;

        }
        public void post(Product product)
        {
            var db = new ShopContext();
            db.Add(product);
            db.SaveChanges();

        }
        public void delete(int id)
        {
            var db = new ShopContext();

            db.Product.Remove(GetById(id));
            db.SaveChangesAsync();
        }
        public Product Update(int id, Product  product)
        {
            var db = new ShopContext();
            if (id != product.Id)
            {
                return null;
            }
            db.Entry(product).State = EntityState.Modified;


            db.SaveChangesAsync();


            return product;

        }
    }
}
