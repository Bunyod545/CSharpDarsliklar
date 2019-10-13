namespace JwtTokenApi.Contexts.Tables
{
    /// <summary>
    /// Api foydalanuvchi ma`lumotlari
    /// </summary>
    public class ApiUser
    {
        /// <summary>
        /// Foydalanuvchini identifikatori
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foydalanuvchini nomi
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Foydalanuvchini logini
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Foydalanuvchini maxfiy ko`di
        /// </summary>
        public string Password { get; set; }
    }
}
