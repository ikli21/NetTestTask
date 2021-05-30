using Microsoft.EntityFrameworkCore;
using NetTestTask.DAL.DataBase;

using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTestTask.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private NetTestTaskDatabase db;

        public UserRepository(NetTestTaskDatabase db)
        {
            this.db = db;
        }

        public User GetUserById(int id)
        => db.Users.FirstOrDefault(u => u.UserId == id);

        public IEnumerable<User> GetUsers()
        => db.Users.ToList();

        public  void SaveChangesAsync()
        =>  db.SaveChanges();//async
        //public async void SaveChangesAsync()
        //=> await db.SaveChangesAsync();//async

        public void UpdateUser(User user)
        => db.Update(user);
    }
}
