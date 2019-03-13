using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using simple_csharp_api.Repository;
using simple_csharp_api.users;

namespace simple_csharp_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAppConfig(Configuration)
            //services.AddDbContext<DatabaseContext>(cfg => cfg.UseSqlServer(""));
            //services.TryAddScoped<IRepository<User>, UserRepository>();


            services.AddEntityFrameworkNpgsql()
               .AddDbContext<DatabaseContext>()
               .BuildServiceProvider();

            services.AddScoped<UserRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseContext context)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    app.UseHttpsRedirection();
            //    var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            //    context.Database.EnsureCreated();
            //}

            context.Database.Migrate();
            //context.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
