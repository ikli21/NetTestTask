using NetTestTask.API.Models;
using NetTestTask.API.Models.TaskModels;
using NetTestTask.API.Models.UserModels;
using NetTestTask.DAL.Repositories;
using NetTestTask.Data.Entities;
using NetTestTask.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetTestTask.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskRepository _taskRepository;

        public UserService(IUserRepository userRepository, ITaskRepository taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public UsersInfoIndexModel GetPageUsers(int pageNum)
        {
            return new UsersInfoIndexModel(_userRepository.GetUsers(),pageNum);
        }

        public User GetUser(int id)
        => _userRepository.GetUserById(id);

        public TaskInfoModel SetTaskForExecutor(int userId, int taskId)
        {
            var user = _userRepository.GetUserById(userId);
            var task = _taskRepository.GetTaskById(taskId);
            if (user != null && task != null)
            {
                task.ExecutorId = user.UserId;
                _taskRepository.SaveChangesAsync();
                return new TaskInfoModel(task) {
                    
                    
                };
            }
            return null;
            
        }

        public User UpdateUser(int id, UpdateUserModel updateUserModel)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                //if model update field equals null
                user.Name = updateUserModel.Name??user.Name;
                user.SurName = updateUserModel.SurName ?? user.SurName;
                if (updateUserModel.CreationDate != null)
                {
                    user.CreationDate = updateUserModel.CreationDate;
                }
                if (updateUserModel.LastChangeDate != null)
                {
                    user.LastChangeDate = updateUserModel.LastChangeDate;
                }
                _userRepository.SaveChangesAsync();
                
            }
            return user;

        }
    }
}
