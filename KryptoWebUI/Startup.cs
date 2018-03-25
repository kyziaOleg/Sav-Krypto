using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KryptoInterface.Interface;
using KryptoModel;
using KryptoRepositoryLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace KryptoWebUI
{
    public class Startup
    {
       // IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
           // Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();//загружает конфигурационые настройки из файла
        }
        public void ConfigureServices(IServiceCollection services)//для настройки разделяемых объектов чере внедрение зависимостей
        {
            services.AddSingleton<IModeLayer>(new ModeLayer(new KryptoRepository()));
            services.AddMvc();
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)// используется для настройки обработчика HTTP-Запросов
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // добавляем сборку через webpack
               /* app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });*/

            }
           
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                // routes.MapRoute(name: null, template: "{controller}/{action}/{id}");
                 routes.MapRoute(name: null, template: "{controller}/{action=List}/{type}");

                routes.MapRoute(name: null, template: "{controller}/{action}/{type}/{id}");

                routes.MapRoute(name: "defaoult", template: "{controller=Main}/{action=List}");
            });         
        }
    }
}
