namespace JwtTokenApi.Models
{
    /// <summary>
    /// Foydalanuvchi ma`lumotlari
    /// </summary>
    public class UserLoginArgs
    {
        /// <summary>
        /// Foydalanuvchi logini
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Foydalanuvchi maxfiy ko`di
        /// </summary>
        public string Password { get; set; }
    }
}
