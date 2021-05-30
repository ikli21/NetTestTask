using NetTestTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTestTask.Data.Extensions
{
    public static class UserExtensions
    {
        public static string StatusTitle(this User user)
        {
            switch (user.UserStatus)
            {
                case UserStatus.Active:
                    return "Активен";
                case UserStatus.Offline:
                    return "Отключен";
                case UserStatus.Blocked:
                    return "Заблокирован";
                default:
                    return "";
            }
        }
    }
}
