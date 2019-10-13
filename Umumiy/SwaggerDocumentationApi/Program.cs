using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SwaggerDocumentationApi
{
    /// <summary>
    /// Kirish qismi 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Kirish metodi
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Apini ishga tushirish
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
