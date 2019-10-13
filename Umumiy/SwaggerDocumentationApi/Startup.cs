using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace SwaggerDocumentationApi
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

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Swagger Documentation Api", Version = "v1" });
                c.IncludeXmlComments(xmlPath);
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Documentation Api v1");
            });
            app.UseMvc();
        }
    }
}
