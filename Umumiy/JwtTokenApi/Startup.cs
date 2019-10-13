using JwtTokenApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenApi
{
    /// <summary>
    /// Apini sozlash
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// App setting file bilan ishlash
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Apini sozlash
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Apidagi servislarni sozlash
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var parametres = new TokenValidationParameters()
            {
                ValidIssuer = AuthConstants.ValidIssuer,
                ValidAudience = AuthConstants.ValidAudience,
                ValidateIssuer = true,

                IssuerSigningKey = AuthConstants.GetSecurityKey(),
                ValidateLifetime = true
            };

            services.AddAuthentication(options => options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o => o.TokenValidationParameters = parametres);
        }

        /// <summary>
        /// Api dasturini sozlash
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
