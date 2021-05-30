using NetTestTask.API.Models.CommonModels;
using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using NetTestTask.Data.Extensions;

namespace NetTestTask.API.Models.UserModels
{
    public class UsersInfoIndexModel
    {
        public UsersInfoIndexModel(IEnumerable<User> users, int pageNum)
        {
            if (users != null)
            {
                int pageSize = 4;
                IEnumerable<User> usersForPage = users.Skip((pageNum - 1) * pageSize).Take(pageSize);
                Page = new PageInfoModel((int)Math.Round((double)users.Count() / pageSize),
                                         pageNum);
                Users = users.Select(u => new UserInfoModel()
                {

                    UserId = u.UserId,
                    Name = u.Name,
                    SurName = u.SurName,
                    UserStatus = UserExtensions.StatusTitle(u),
                    CreationDate = u.CreationDate,
                    LastChangeDate = u.LastChangeDate


                });
            }
        }

        public PageInfoModel Page { get; set; }
        public IEnumerable<UserInfoModel> Users { get; set; } = Enumerable.Empty<UserInfoModel>();
        
    }
}
