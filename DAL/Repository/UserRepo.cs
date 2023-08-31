using DAL.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepo
    {
        public List<User> GetAllUsers()
        {
            var db = new ShopContext();
            return db.User.ToList();
        }
        public User GetUserById(int id) 
        {
            var db = new ShopContext();
            User user = new User();
            user = db.User.FirstOrDefault(x => x.Id == id);
            
            return user; 

        }
        public void postUser(User user) 
        { 
            var db = new ShopContext();
            db.Add(user);
            db.SaveChanges();
           
        }
        public void deleteUser(int id) 
        {
            var db = new ShopContext();
            
            db.User.Remove(GetUserById(id));
            db.SaveChangesAsync();
        }
        public User Update(int id,User user) 
        {
            var db = new ShopContext();
            if (id != user.Id)
            {
                return null;
            }
            db.Entry(user).State = EntityState.Modified;

            
               db.SaveChangesAsync();
            

            return user;

        }
        public bool Auth(string name, string password) 
        {
            var db = new ShopContext();
            var data = db.User.FirstOrDefault(x=>x.Name.Equals(name) && x.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

      
    }
}
