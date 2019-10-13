namespace JwtTokenApi.Models
{
    /// <summary>
    /// Foydalanuvchi haqida ma`lumot
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Foydalanuvchi logini
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Foydalanuvchi nomi
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Foydalanuvchi haqida ma`lumot
        /// </summary>
        /// <param name="userLogin">Foydalanuvchi logini</param>
        /// <param name="userName">Foydalanuvchi nomi</param>
        public UserInfo(string userLogin, string userName)
        {
            UserLogin = userLogin;
            UserName = userName;
        }
    }
}
