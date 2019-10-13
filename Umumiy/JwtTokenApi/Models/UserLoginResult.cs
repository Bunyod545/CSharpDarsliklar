namespace JwtTokenApi.Models
{
    /// <summary>
    /// Foydalanuvchi ro`yhatdan o`tilganligi haqidagi ma`lumotlar
    /// </summary>
    public class UserLoginResult
    {
        /// <summary>
        /// Muvaffaqiyatli ro`yhatdan o`tdimi ?
        /// </summary>
        public bool IsSuccessfully { get; set; }

        /// <summary>
        /// Foydalanuvchi tokeni
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Ro`yhatdan o`tishdagi habar
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Ro`yhatdan o`tishdagi habar ko`di
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Foydalanuvchi ro`yhatdan o`tilganligi haqidagi malumotlar
        /// </summary>
        public UserLoginResult()
        {

        }

        /// <summary>
        /// Foydalanuvchi ro`yhatdan o`tilganligi haqidagi malumotlar
        /// </summary>
        /// <param name="isSuccessfully">Muvaffaqiyatli ro`yhatdan o`tdimi ?</param>
        /// <param name="token">Foydalanuvchi tokeni</param>
        public UserLoginResult(bool isSuccessfully, string token)
        {
            IsSuccessfully = isSuccessfully;
            Token = token;
        }

        /// <summary>
        /// Foydalanuvchi ro`yhatdan o`tilganligi haqidagi malumotlar
        /// </summary>
        /// <param name="code">Ro`yhatdan o`tishdagi habar ko`di</param>
        /// <param name="message">Ro`yhatdan o`tishdagi habar</param>
        public UserLoginResult(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
