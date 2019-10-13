using System.Collections.Generic;
using JwtTokenApi.Contexts.Tables;

namespace JwtTokenApi.Contexts
{
    /// <summary>
    /// Malumotlar ombori bilan ishlovchi context
    /// </summary>
    public class ApiContext
    {
        /// <summary>
        /// Foydalanuvchilar ro`yhati
        /// </summary>
        public List<ApiUser> Users { get; }

        /// <summary>
        /// Malumotlar ombori bilan ishlovchi context
        /// </summary>
        public ApiContext()
        {
            Users = new List<ApiUser>();

            var user1 = new ApiUser();
            user1.Id = 1;
            user1.Name = "User 1";
            user1.Login = "User1Login";
            user1.Password = "User1Password";

            var user2 = new ApiUser();
            user2.Id = 2;
            user2.Name = "User 2";
            user2.Login = "User2Login";
            user2.Password = "User2Password";

            Users.Add(user1);
            Users.Add(user2);
        }
    }
}
