using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using JwtTokenApi.Contexts;
using JwtTokenApi.Contexts.Tables;
using JwtTokenApi.Helpers;
using JwtTokenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenApi.Controllers
{
    /// <summary>
    /// Foydalanuchini authetikatsiya qilish apisi
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        /// <summary>
        /// Malumotlar ombori bilan ishlovchi context
        /// </summary>
        private readonly ApiContext _apiContext;

        /// <summary>
        /// Foydalanuchini authetikatsiya qilish apisi
        /// </summary>
        public UserAuthController()
        {
            _apiContext = new ApiContext();
        }

        /// <summary>
        /// Foydalanuvchini ro`yhatdan o`tkazish
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public UserLoginResult Login(UserLoginArgs args)
        {
            var user = _apiContext.Users.FirstOrDefault(f => f.Login == args.Login);
            if (user == null)
                return new UserLoginResult(-1, "Foydalanuvchi yoki maxfiy ko`d noto`g`ri!");

            if (user.Password != args.Password)
                return new UserLoginResult(-1, "Foydalanuvchi yoki maxfiy ko`d noto`g`ri!");

            var token = GetToken(user);
            return new UserLoginResult(true, token);
        }

        /// <summary>
        /// Foydalanuvchini to`kenini olish
        /// </summary>
        /// <param name="user">Foydalanuvchini ma`lumotlari</param>
        /// <returns></returns>
        private string GetToken(ApiUser user)
        {
            var token = new JwtSecurityToken(
                AuthConstants.ValidIssuer,
                AuthConstants.ValidAudience,
                new[] { new Claim(nameof(ApiUser.Id), user.Id.ToString()) },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                    AuthConstants.GetSecurityKey(),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Foydalanuvchi haqida ma`lumotni olish
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize]
        public UserInfo GetUserInfo()
        {
            var userIdClaim = HttpContext.User.FindFirst(nameof(ApiUser.Id));
            var userId = int.Parse(userIdClaim.Value);

            var user = _apiContext.Users.FirstOrDefault(f => f.Id == userId);
            return new UserInfo(user?.Login, user?.Name);
        }
    }
}