using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Services;

namespace UI
{
    public class Startup
    {
        IConfiguration Configuration { get; set; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(StoreService));

            foreach (TypeInfo T in
                      typeof(StoreService).Assembly.DefinedTypes
                      .Where(i => i.Name.EndsWith("Service")))
            {
                services.AddScoped(T);
            }

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped(typeof(UnitOfWork));
            services.AddScoped(typeof(Generic<>));
            services.AddScoped(typeof(EntitiesContext));
            services.AddDbContext<EntitiesContext>
                (i => i.UseSqlServer(Configuration.GetConnectionString("CompuMedical")));

            services.AddMvc(i => i.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(i =>
            {
                i.MapRoute
                ("default", "{controller}/{action}",
                new { controller = "Home", action = "Index" });
            });


        }
    }
}
