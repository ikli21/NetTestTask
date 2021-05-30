using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTestTask.DAL.Repositories
{
    public interface IUserRepository
    {

        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void SaveChangesAsync();
        void UpdateUser(User user);
        


    }
}
