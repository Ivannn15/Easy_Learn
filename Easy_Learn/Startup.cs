using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Easy_Learn.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Easy_Learn
{
    public class Startup
    {

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsetting.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // добавляем поддержку контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                // выставляем совместимость с asp.net core 3.0 
                .SetCompatibilityVersion(version: CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            services.Add(item: new ServiceDescriptor(serviceType: typeof(wordModel), instance: new wordModel(connectionString: Configuration.GetConnectionString(name: "DefaultConnection"))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // отслеживание информации об ошибках
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();

            // подключение поддержки статичных файлов в приложении html css js
            app.UseStaticFiles();

            // регистрируем нужные нам маршруты (эндпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Word}/{action=Index}/{id?}");
            });
        }
    }
}
