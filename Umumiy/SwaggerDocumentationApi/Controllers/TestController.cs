using Microsoft.AspNetCore.Mvc;

namespace SwaggerDocumentationApi.Controllers
{
    /// <summary>
    /// Testoviy controller
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Testoviy sobsheniyani olish
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetTestMessage()
        {
            return "Testoviy sobsheniya :)";
        }

        /// <summary>
        /// Salom yo`llash
        /// </summary>
        /// <param name="name">Salom yo`naltirilgan inson ismi</param>
        /// <returns></returns>
        [HttpGet]
        public string SayHello(string name)
        {
            return $"Salom {name}";
        }
    }
}