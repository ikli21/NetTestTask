using NetTestTask.API.Models;
using NetTestTask.Data.Entities;
using NetTestTask.API.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTestTask.API.Models.UserModels;

namespace NetTestTask.API.Services
{
    public interface IUserService
    {

        UsersInfoIndexModel GetPageUsers(int pageNum);
        User GetUser(int id);
        User UpdateUser(int id, UpdateUserModel updateUserModel);
        TaskInfoModel SetTaskForExecutor(int userId, int taskId);



    }
}
