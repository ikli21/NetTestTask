using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTestTask.API.Models;
using NetTestTask.API.Services;
using NetTestTask.Data.Extensions;

namespace NetTestTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        [Route("{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUser(userId);
            if (user is null)
            {
                return BadRequest("Пользователь не найден");
            }
            var userInfoModel = new UserInfoModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                SurName = user.SurName,
                CreationDate = user.CreationDate,
                LastChangeDate = user.LastChangeDate,
                UserStatus = UserExtensions.StatusTitle(user)
            };
            return Ok(userInfoModel);

        }
        [HttpPut]
        [Route("{userId:int}")]
        public IActionResult UpdateUser(int userId, [FromBody]UpdateUserModel updateUserModel)
        {
            var user = _userService.UpdateUser(userId, updateUserModel);
            if (user is null)
            {
                return BadRequest("Пользователь не найден");
            }
            var userInfoModel = new UserInfoModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                SurName = user.SurName,
                CreationDate = user.CreationDate,
                LastChangeDate = user.LastChangeDate,
                UserStatus = UserExtensions.StatusTitle(user)
            };
            return Ok(userInfoModel);

        }
        [HttpGet]
        [Route("users/{pageNum:int}")]
        public IActionResult GetPageUsers(int pageNum)
        {
            var page = _userService.GetPageUsers(pageNum);
            if (page is null)
            {
                return BadRequest("Страница не найдена");
            }

            return Ok(page);

        }
        [HttpPut]
        [Route("{userId:int}/executor/{taskId:int}")]
        public IActionResult SetTaskForExecutor(int userId, int taskId)
        {

            var task = _userService.SetTaskForExecutor(userId, taskId);
            if(task is null)
            {
                return BadRequest("Не найден пользователь или задача");

            }
            return Ok(task);

        }
        

    }
}
